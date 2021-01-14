using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Auth;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CrudControllerBase<UserDTO, User, UserEntity, int>
    {
        protected IUserService UserService => (IUserService) Service;
        public UserController(IUserService service, IMapper mapper) : base(service, mapper)
        {
        }

        #region Get token (login)
        [HttpPost("/api/admin/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Token(string username, [FromBody] string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new {errorText = "Invalid username or password."});
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return new JsonResult(response);
        }

        private ClaimsIdentity GetIdentity(string login, string password)
        {

            var person = UserService.Login(login, password).Result;
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            
            return null;
        }
        #endregion

        #region Registration

        //todo create endpoint for registration

        #endregion

        #region Update

        public async Task<ActionResult<UserDTO>> ChangeRole(int userId, string role)
        {
            User user = await UserService.UpdateRole(userId, role);
            var result = Mapper.Map<UserDTO>(user);
            return result;
        }

        //todo create update methods 

        #endregion


    }
}