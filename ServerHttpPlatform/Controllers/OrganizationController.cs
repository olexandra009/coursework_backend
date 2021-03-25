using System.Threading.Tasks;
using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : CrudControllerBase<OrganizationDTO, Organization, OrganizationEntity, int>
    {
        protected IOrganizationService OrganizationService => (OrganizationService)Service;

        public OrganizationController(IOrganizationService service, IMapper mapper) : base(service, mapper)
        {

        }

      
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "UserManager")]
        public override Task<ActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "UserManager")]
        public override Task<ActionResult<OrganizationDTO>> Update(int id, OrganizationDTO dto)
        {
            return base.Update(id, dto);
        }
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "UserManager")]
        public override Task<ActionResult<OrganizationDTO>> Create(OrganizationDTO dto)
        {
            return base.Create(dto);
        }
    }
}
