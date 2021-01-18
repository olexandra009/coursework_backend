using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    //todo implement methods 
    public interface IUserService : IServiceCrudModel<User,int,UserEntity>
    {
        Task Registration();
        Task<User> Login(string login, string password);
        Task<User> UpdateRole(int id, string role);
    }
    public class UserService:ServiceCrudModel<User, int, UserEntity>, IUserService
    {

        protected IOrganizationService OrganizationService;
    
        public UserService(IMapper mapper, IOrganizationService organizationService, IUserRepository repository) : base(mapper, repository)
        {
            OrganizationService = organizationService;
        }

        ////override to add organization
        //public override async Task<List<User>> List(ISpecification<UserEntity> specification)
        //{
        //    List<UserEntity> entities = await Repository.ListAsync(specification);
        //    List<User> models = Mapper.Map<List<User>>(entities);
        //    foreach (var user in models)
        //    {
        //        if(user.UserOrganizationId==null) continue;
        //        user.UserOrganization = await OrganizationService.Get((int)user.UserOrganizationId);

        //    }
        //    return models;
        //}

       

        public async Task Registration()
        {
            throw new System.NotImplementedException();
        }


        public async Task<User> Login(string login, string password)
        {
            var user = Repository.ListAsync(new UserByLoginSpecification(login, password)).Result.FirstOrDefault();
            var result = Mapper.Map<User>(user);
            return result;

        }

        public async Task<User> UpdateRole(int id, string role)
        {
            var user = await Repository.GetByIdAsync(id);
            var userModel = Mapper.Map<User>(user);
            userModel.Role = role;
            var userEntity = Mapper.Map<UserEntity>(userModel);
            await Repository.UpdateAsync(userEntity);
            User result = Mapper.Map<User>(userEntity);
            result = await Task.FromResult(result).ConfigureAwait(false);
            return result;
        }
    }
}
