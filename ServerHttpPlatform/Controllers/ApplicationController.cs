using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using JetBrains.Annotations;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : CrudControllerBase<ApplicationDTO, Application, ApplicationEntity, int>
    {
        protected IApplicationService ApplicationService => (ApplicationService) Service;
        public ApplicationController(IApplicationService service, IMapper mapper) : base(service, mapper)
        {

        }

        //todo override edit
        //todo do we need page result?
        #region Get List
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override Task<ListResult<ApplicationDTO>> GetList(PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "OpenDate";
            return base.GetList(query);
        }

        [HttpGet("/getListFilteredByStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ListResult<ApplicationDTO>>> GetFilteredByStatusList(StatusDTO status, [FromQuery] PagedSortListQuery query)
        {
           
            var statusModel = Mapper.Map<StatusModel>(status);
            var statusEntity = Mapper.Map<Status>(statusModel);
            var modelList = await ApplicationService.List(new FilterByStatusApplicationSpecification(statusEntity, query));
            ListResult<ApplicationDTO> result = new ListResult<ApplicationDTO>
            {
                Result = Mapper.Map<List<ApplicationDTO>>(modelList),
                Total = await Service.Count(new FilterByStatusApplicationSpecification(statusEntity, query.TakeAll()))
            };
            return result;
        }

        [HttpGet("/getListFilteredByAuthor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ListResult<ApplicationDTO>>> GetFilteredByAuthorAndStatus(int authorId, [FromQuery] PagedSortListQuery query, [FromQuery] StatusDTO status = StatusDTO.NullStatus)
        {
            var statusModel = Mapper.Map<StatusModel>(status);
            var statusEntity = Mapper.Map<Status>(statusModel);
            var modelList = await ApplicationService.List(new ApplicationsByAuthorIdSpecification(authorId, query, statusEntity));
            ListResult<ApplicationDTO> result = new ListResult<ApplicationDTO>
            {
                Result = Mapper.Map<List<ApplicationDTO>>(modelList),
                Total = await Service.Count(new ApplicationsByAuthorIdSpecification(authorId, query.TakeAll(), statusEntity))
            };
            return result;
        }


        [HttpGet("/getListFilteredByAnswerer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ListResult<ApplicationDTO>>> GetFilteredByAnswerer([FromQuery] PagedSortListQuery query, Status status, int? answererId = null)
        {
            var statusModel = Mapper.Map<StatusModel>(status);
            var statusEntity = Mapper.Map<Status>(statusModel);
            var modelList = await ApplicationService.List(new ApplicationByAnswererIdSpecification(answererId, query, statusEntity));
            ListResult<ApplicationDTO> result = new ListResult<ApplicationDTO>
            {
                Result = Mapper.Map<List<ApplicationDTO>>(modelList),
                Total = await Service.Count(new ApplicationByAnswererIdSpecification(answererId, query.TakeAll(), statusEntity))
            };
            return result;
        }
        #endregion

        #region Update
        //TODO Change multimedia 

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<ApplicationDTO>> Update(int id, ApplicationDTO dto) 
        {
            return base.Update(id, dto);
        }

        [HttpPut("/addResult/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationDTO>> AddResult(int id, [FromBody]string result)
        {
            var exist = await ApplicationService.Get(id);
            if (exist == null)
                return NotFound();
            var app = await ApplicationService.AddResult(id, result);
            var appDto = Mapper.Map<ApplicationDTO>(app);
            return appDto;
        }

        [HttpPut("/changeStatus/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationDTO>> ChangeStatus(int id, StatusDTO statusDto)
        {
            var exist = await ApplicationService.Get(id);
            if (exist == null)
                return NotFound();
            var status = Mapper.Map<StatusModel>(statusDto);
            var app = await ApplicationService.ChangeStatus(id, status);
            var appDto = Mapper.Map<ApplicationDTO>(app);
            return appDto;
        }


        [HttpPut("/changeTextOrSubject/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationDTO>> EditTextOrHeader(int id, ApplicationDTO application)
        {
            var exist = await ApplicationService.Get(id);
            if (exist == null)
                return NotFound();
            var model = Mapper.Map<Application>(application);
            var app = await ApplicationService.ChangeTextOrSubject(id, model);
            var appDto = Mapper.Map<ApplicationDTO>(app);
            return appDto;
        }
        #endregion

        #region Delete

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public override async Task<ActionResult> Delete(int id)
        {
            try
            {
                return await base.Delete(id);
            }
            catch (NotSupportedException exception)
            {
                return NotFound(exception.Message);
            }
          
        }

        #endregion
    }
}
