﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        #region Get
        //todo write and implement GetList
        // todo write notFound
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<ActionResult<TDto>>Create([FromBody] TDto dto)
        {
            var model = Mapper.Map<TModel>(dto);
            if (!(model.Id.Equals(default(TKey)))) throw new ArgumentException();
            var createdModel = await Service.Create(model);
            var result = Mapper.Map<TDto>(createdModel);
            return result;
        }

        public virtual async Task Delete(TKey id)
        {
            if (await Service.Exist(id))
                await Service.Delete(id);
        }


        #endregion
    }
}
