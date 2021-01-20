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
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


// summary should be done
//  create registration methods with email confirmation 
//  create updates methods: all user information, password, email(with new confirmation)
//  list of users that voted petition 
//  authorization for each endpoint 

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
        /// <summary>
        /// Get authentication token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public IActionResult Token([FromBody]LoginUserDtO user)
        {
            var identity = GetIdentity(user.Login, user.Password);
            if (identity == null)
            {
                return NotFound(new {errorText = "Invalid username or password."});
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
        /// <summary>
        /// New user registration (create new user)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("/registration")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserDTO>> Registration(UserDTO dto)
        {
            var model = Mapper.Map<User>(dto);
            try
            {
                model = await UserService.Registration(model);
            }
            catch (ArgumentException e)
            {
                return Conflict(e);
            }
            return Mapper.Map<UserDTO>(model);
        }
        #endregion



        #region Get List
        /// <summary>
        /// Get list of users by their roles
        /// </summary>
        /// <param name="role"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("/filtered_by_role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResult<UserDTO>>> GetByRole(string role, PagedSortListQuery query)
        {
            var modelList = await UserService.List(new UserByRoleSpecification(role, query));
            var result = new ListResult<UserDTO>()
            {
                Result = Mapper.Map<List<UserDTO>>(modelList),
                Total = await UserService.Count(new UserByRoleSpecification(role, query.TakeAll()))
            };
            return result;
        }

        #endregion


        #region Update
        /// <summary>
        /// Change users role
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role">allows values: user, superuser, handAppAdmin, moderator, admin, userManagerAdmin</param>
        /// <returns></returns>
        [HttpPut("/change_role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
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