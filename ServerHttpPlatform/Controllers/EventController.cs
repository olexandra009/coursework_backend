using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//summary should be done:
//  create notificationEmail sender
//  add authorization for endpoints 
//  overload edit to allow changing multimedia (delete old and upload new)  

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

        #region Get List 

        /// <summary>
        /// Get list of events sorted by id by default
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public override Task<ListResult<EventDTO>> GetList(PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "Id";
            return base.GetList(query);
        }

        /// <summary>
        /// Get list of events filtered by status: active, or passed 
        /// </summary>
        /// <param name="filter">allows values active, pass</param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/filter_by_time")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ListResult<EventDTO>>> FilteredByTime(string filter, [FromQuery]PagedSortListQuery query)
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

        /// <summary>
        /// Get list of events created by organization
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/filter_by_organization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResult<EventDTO>>> FilteredByOrganization(int organizationId, [FromQuery]PagedSortListQuery query)
        {
            var modelList = await EventService.List(new CreatedEventsOrganizationIdSpecification(organizationId, query));
            var result = new ListResult<EventDTO>()
            {
                Result = Mapper.Map<List<EventDTO>>(modelList),
                Total = await EventService.Count(new CreatedEventsOrganizationIdSpecification(organizationId, query.TakeAll()))
            };
            return result;
  
        }


        [HttpGet("/filterOrganizationTime")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResult<EventDTO>>> FilteredByOrganizationAndTime(int organizationId, string filter, [FromQuery]PagedSortListQuery query)
        {
            var modelList = await EventService.List(new SortedEventsByOrganizationAndTimeSpecification(organizationId,filter,query));
            var result = new ListResult<EventDTO>()
            {
                Result = Mapper.Map<List<EventDTO>>(modelList),
                Total = await EventService.Count(new SortedEventsByOrganizationAndTimeSpecification(organizationId, filter, query.TakeAll()))
            };
            return result;

        }
        #endregion

        #region Create

        /// <summary>
        /// Create event 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override async Task<ActionResult<EventDTO>> Create(EventDTO dto)
        {
            return await base.Create(dto);
        }


        #endregion

    }
}
