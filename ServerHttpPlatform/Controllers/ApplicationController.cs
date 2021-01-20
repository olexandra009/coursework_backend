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
// methods for change and upload multimedia (maybe client should ask server in request to multimedia)
// methods and endpoint for changing answerer
// add authorization to endpoints 

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
 
        #region Get List
        /// <summary>
        /// Get a list of items 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        public override Task<ListResult<ApplicationDTO>> GetList(PagedSortListQuery query)
        {
            if (string.IsNullOrEmpty(query.SortProp))
                query.SortProp = "OpenDate";
            return base.GetList(query);
        }

        /// <summary>
        /// Get list of application filtered by status
        /// </summary>
        /// <param name="status">
        /// <value>0 - used as null, </value>
        /// <value>1 - Waiting, </value>
        /// <value>2 - In progress, </value>
        /// <value>3 - Close</value>
        /// </param>
        /// <param name="query"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get list of application created by user with authorId and filtered by status (optional)
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="query"></param>
        /// <param name="status">
        /// <value>0 - used as null, </value>
        /// <value>1 - Waiting, </value>
        /// <value>2 - In progress, </value>
        /// <value>3 - Close</value>
        /// </param>
        /// <returns></returns>
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

        /// <summary>
        /// Get list of application created by user with answererId and filtered by status (optional)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="status">In process by default</param>
        /// <param name="answererId"></param>
        /// <returns></returns>
        [HttpGet("/getListFilteredByAnswerer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ListResult<ApplicationDTO>>> GetFilteredByAnswerer([FromQuery] PagedSortListQuery query, StatusDTO status = StatusDTO.InProcess, int? answererId = null)
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
        //TODO Change and upload multimedia 
        //TODO Change answerer

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<ApplicationDTO>> Update(int id, ApplicationDTO dto) 
        {
            return base.Update(id, dto);
        }
        /// <summary>
        /// Add result to application
        /// </summary>
        /// <param name="id"></param>
        /// <param name="result"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Change application status 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusDto">
        /// <value>0 - not allowed in this context, </value>
        /// <value>1 - Waiting, </value>
        /// <value>2 - In progress, </value>
        /// <value>3 - Close</value>
        /// </param>
        /// <returns></returns>
        [HttpPut("/changeStatus/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationDTO>> ChangeStatus(int id, StatusDTO statusDto)
        {
            if (statusDto == StatusDTO.NullStatus) return NotFound("Not allowed such status");
            var exist = await ApplicationService.Get(id);
            if (exist == null)
                return NotFound();
            var status = Mapper.Map<StatusModel>(statusDto);
            var app = await ApplicationService.ChangeStatus(id, status);
            var appDto = Mapper.Map<ApplicationDTO>(app);
            return appDto;
        }

        /// <summary>
        /// To change text or subject 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="application"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete application 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
