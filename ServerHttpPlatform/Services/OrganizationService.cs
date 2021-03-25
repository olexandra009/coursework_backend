using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Repositories;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services.Common;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services
{
    public interface IOrganizationService:IServiceCrudModel<Organization, int, OrganizationEntity>
    {
    }
    public class OrganizationService : ServiceCrudModel<Organization, int, OrganizationEntity>, IOrganizationService
    {

   

        public OrganizationService(IMapper mapper, IOrganizationRepository repository) : base(mapper, repository)
        {
           
        }

        public override Task<Organization> Update(Organization model)
        {
            model.Users = null;
            return base.Update(model);
        }
    }
}
