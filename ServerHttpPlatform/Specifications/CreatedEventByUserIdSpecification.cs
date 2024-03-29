﻿using Ardalis.Specification;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications
{
    public class CreatedEventByUserIdSpecification : Specification<EventEntity>
    {
        /// <summary>
        /// Creates specification query for get list of petition created by user with userId
        /// </summary>
        /// <param name="userId"></param>
        public CreatedEventByUserIdSpecification(int userId)
        {
            Query.Where(e => e.AuthorId == userId);
        }
    }
}
