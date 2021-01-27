using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//summary should be done:
//  write text to notFound

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common
{
    public class CrudControllerBase<TDto, TModel, TEntity, TKey>:ControllerBase 
        where TModel: IModel<TKey>
        where TEntity : class
    {
        protected readonly IServiceCrudModel<TModel, TKey, TEntity> Service;
        protected readonly IMapper Mapper;

        public CrudControllerBase(IServiceCrudModel<TModel, TKey, TEntity> service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }
        /// <summary>
        /// Get list of items
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ListResult<TDto>> GetList([FromQuery]PagedSortListQuery query)
        {
            var model = await Service.List(query);
            ListResult<TDto> result = new ListResult<TDto>
            {
                Result = Mapper.Map<List<TDto>>(model), 
                Total =  await Service.Count(query.TakeAll())
            };
            return result;
        }

        // TODO write notFound
        /// <summary>
        /// Get item by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDto>> Get(TKey id)
        {
            var model = await Service.Get(id);
            if (model == null)
                return NotFound();
            var result = Mapper.Map<TDto>(model);
            return result;

        }
        /// <summary>
        /// Update item by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TDto>> Update(TKey id, [FromBody] TDto dto)
        {
            var exist = await Service.Get(id);
            if (exist == null)
                return NotFound();
            var model = Mapper.Map<TModel>(dto);
            model.Id = id;
            var update = await Service.Update(model);
            var result = Mapper.Map<TDto>(update);
            return result;
        }
        /// <summary>
        /// Create item
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<ActionResult<TDto>>Create([FromBody] TDto dto)
        {
            var model = Mapper.Map<TModel>(dto);
            if (!(model.Id.Equals(default(TKey)))) throw new ArgumentException();
            var createdModel = await Service.Create(model);
            var result = Mapper.Map<TDto>(createdModel);
            return Created("", result);
        }
        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<ActionResult> Delete(TKey id)
        {
            if (await Service.Exist(id))
                await Service.Delete(id);
            return NoContent();
        }

    }
}
