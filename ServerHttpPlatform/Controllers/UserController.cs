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
using AutoMapper.QueryableExtensions;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Auth;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


// summary should be done
//  create registration methods with email confirmation 
//  create updates methods: all user information, password, email(with new confirmation)
//  list of users that voted petition 
//  authorization for each endpoint 

//TODO create update methods for user
namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
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
            ClaimsIdentity identity;
            try
            {
                identity = GetIdentity(user.Login, user.Password);
            }
            catch(AccessViolationException e)
            {
                return NotFound(new { errorText = e.Message });
            }

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

            var u = UserService.Login(user.Login, user.Password).Result;
            var userDto = Mapper.Map<UserDTO>(u);
            userDto.Password = "hidden";
            var response = new
            {
                access_token = encodedJwt,
                user = userDto,
            };
            return new JsonResult(response);
        }

        private ClaimsIdentity GetIdentity(string login, string password)
        {

            var person = UserService.Login(login, password).Result;
            if (person != null)
            {
                if (!person.EmailConfirm) throw new AccessViolationException("Email is not confirm!");
                var roles = person.Role.Split(", ");
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                };
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
                }
               
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
                var response = Mapper.Map<UserDTO>(model);
                response.Password = "hidden";
                return response;
            }
            catch (ArgumentException e)
            {
                return Conflict(e);
            }
        }

        [HttpPut("/user/check")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public IActionResult CheckToken()
        {
            return Ok(new { token = true });
        }


        [HttpPost("/loginExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> IsLoginExists(string login)
        {
            var user = await UserService.GetUserByLogin(login);
            if (user == null) return NotFound();
            return Ok();
        }

        //TODO should we send page here?
        [HttpGet("/confirm_email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Confirmation([FromQuery]int id, [FromQuery]string code)
        {
            var user = await UserService.ConfirmEmail(id, code);
            if (user == null) return NotFound(); 
            return Ok();
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
        public async Task<ActionResult<ListResult<UserDTO>>> GetByRole(string role, [FromQuery]PagedSortListQuery query)
        {
            var modelList = await UserService.List(new UserByRoleSpecification(role, query));
            modelList.ForEach(a=>a.Password="hidden");
            var result = new ListResult<UserDTO>()
            {
                Result = Mapper.Map<List<UserDTO>>(modelList),
                Total = await UserService.Count(new UserByRoleSpecification(role, query.TakeAll()))
            };
            return result;
        }


        [HttpGet("/api/get_user_by_organization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<UserDTO>>> GetDto(int id)
        {
            var users = await UserService.GetUserByOrganizationId(id);
            return Mapper.Map<List<UserDTO>>(users);
        }


        public override async Task<ListResult<UserDTO>> GetList(PagedSortListQuery query)
        {
            var users= await base.GetList(query);
            users.Result.ForEach(u=> u.Password="hidden");
            return users;
        }

        #endregion


        #region Update
        /// <summary>
        /// Change users role
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role">allows values: </param>
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

        [ApiExplorerSettings(IgnoreApi = true)]
        public override Task<ActionResult<UserDTO>> Update(int id, UserDTO dto)
        {
            return base.Update(id, dto);
        }

        [HttpPut("/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> UpdateUser(int userId, UserDTO user)
        {
            var update = Mapper.Map<User>(user);
            var model = await UserService.UpdateUser(userId, update);
            var dto = Mapper.Map<UserDTO>(model);
            return dto;
        }

        [HttpPut("/update_email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> UpdateEmail(int userId, [FromForm] string email)
        {
           var user =  await UserService.ChangeEmail(userId, email);
           return Mapper.Map<UserDTO>(user);
        }


        [HttpPut("/change_login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> ChangeLogin([FromQuery]int userId, [FromForm]string login)
        {
            User user = await UserService.ChangeLogin(userId, login);
            if (user == null) return NotFound();
            var result = Mapper.Map<UserDTO>(user);
            return result;
        }

        [HttpPut("/change_password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword([FromQuery] int userId, [FromForm] string password)
        {
            User user = await UserService.ChangePassword(userId, password);
            if (user == null) return NotFound();
            return Ok();
        }

        //[HttpPost("/extendRole")]
        //public async Task<ActionResult<UserDTO>> ExtendRole(int userId, [FromBody]string inp)
        //{


        //    return result;
        //}
        #endregion


    }
}