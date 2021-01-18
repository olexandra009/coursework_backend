using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : CrudControllerBase<EventDTO, Event,EventEntity,int>
    {
        protected IEventService EventService => (EventService) Service;
        public EventController(IEventService service, IMapper mapper) : base(service, mapper)
        {
        }

        public override Task<ListResult<EventDTO>> GetList(PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "Id";
            return base.GetList(query);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">allows values active, pass</param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/filter_by_time")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ListResult<EventDTO>>> FilteredByTime(string filter, PagedSortListQuery query)
        {
            try
            {
                var modelList = await EventService.List(new FilterPagedEventSpecification(filter, query));
                var result = new ListResult<EventDTO>()
                {
                    Result = Mapper.Map<List<EventDTO>>(modelList),
                    Total = await EventService.Count(new FilterPagedEventSpecification(filter, query.TakeAll()))
                };
                return result;
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("/filter_by_organization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResult<EventDTO>>> FilteredByOrganization(int organizationId, PagedSortListQuery query)
        {
            var modelList = await EventService.List(new CreatedEventsOrganizationIdSpecification(organizationId, query));
            var result = new ListResult<EventDTO>()
            {
                Result = Mapper.Map<List<EventDTO>>(modelList),
                Total = await EventService.Count(new CreatedEventsOrganizationIdSpecification(organizationId, query.TakeAll()))
            };
            return result;
  
        }

        public override Task<ActionResult<EventDTO>> Create(EventDTO dto)
        {
            
            if (dto.EmailNotification)
            {
                //todo create notificationEmail sender
            }
            return base.Create(dto);
        }




    }
}
