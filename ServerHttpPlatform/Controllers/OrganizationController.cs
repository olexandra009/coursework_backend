using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using Microsoft.AspNetCore.Mvc;

//summary should be done:
//  add authorization to create/edit/delete methods
namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : CrudControllerBase<OrganizationDTO, Organization, OrganizationEntity, int>
    {

        public OrganizationController(IOrganizationService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
