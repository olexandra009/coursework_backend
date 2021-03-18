using AutoMapper;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Models;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Controllers.Common;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Auth;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Services;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications;
using KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Specifications.Common;
using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Get authentication token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [AllowAnonymous]
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
                    new Claim("person/user/identificate", person.Id.ToString()),

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

        #region ForgotPassword
        [HttpPost("/forgot_password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await UserService.GetUserByEmail(email);
            if (user == null) return NotFound();
            var identity = GetIdentity(user.Login, user.Password);
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
            await UserService.SendResetPasswordEmail(user.Id, encodedJwt, user.FirstName,email);

            return Ok();
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
        [AllowAnonymous]
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

        [HttpPost("/emailExists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailExists(string email)
        {
            var user = await UserService.GetUserByEmail(email);
            if (user == null) return NotFound();
            return Ok();
        }
        [HttpGet("/emailConfirmResend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> ReSendEmail([FromQuery]string email)
        {
            bool result = await UserService.ReSendEmailConfirmation(email);
            if (!result) return NotFound();
            return Ok();
        }

       
        [HttpGet("/confirm_email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [AllowAnonymous]
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Moderator,ApplicationAdmin,UserManager")]
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "UserManager")]
        public async Task<ActionResult<List<UserDTO>>> GetDto(int id)
        {
            var users = await UserService.GetUserByOrganizationId(id);
            return Mapper.Map<List<UserDTO>>(users);
        }

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Moderator, ApplicationAdmin, UserManager")]
        public override async Task<ListResult<UserDTO>> GetList(PagedSortListQuery query)
        {
            var users= await base.GetList(query);
            users.Result.ForEach(u=> u.Password="hidden");
            return users;
        }

        #endregion
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public override async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await base.Get(id);
            user.Value.Password = "hidden";
            return user;

        }

        [HttpPut("/user/check")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public IActionResult CheckToken()
        {
            return Ok(new { token = true});
        }


        #region Update
        /// <summary>
        /// Change users role
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPut("/change_role")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "UserManager")]
        public async Task<ActionResult<UserDTO>> ChangeRole(int userId, UserDTO userDto)
        {
            var user = await UserService.UpdateRole(userId, userDto.Role);
            user.Password = "hidden";
            return Mapper.Map<UserDTO>(user);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override  Task<ActionResult<UserDTO>> Update(int id, UserDTO dto)
        {
            return  base.Update(id, dto);
        }

        [HttpPut("/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int userId, UserDTO user, [FromHeader] string authorization)
        {
            var changedId = GetUserIdFromToken(authorization);
            if (changedId != userId) return Unauthorized();
            var update = Mapper.Map<User>(user);
            var model = await UserService.UpdateUser(userId, update);
            var dto = Mapper.Map<UserDTO>(model);
            dto.Password = "hidden";
            return dto;
        }

        [HttpPut("/updateOrganization")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "UserManager")]
        public async Task<ActionResult<UserDTO>> UpdateUserOrganization([FromQuery]int userId, [FromQuery]int organization)
        {
            var user =await  UserService.ChangeOrganization(userId, organization);
            return Mapper.Map<UserDTO>(user);
        }

        [HttpPut("/update_email")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public async Task<ActionResult<UserDTO>> UpdateEmail(int userId, UserDTO userDto, [FromHeader] string authorization)
        {
            var changedId = GetUserIdFromToken(authorization);
            if (changedId != userId) return Unauthorized();

            var user = await UserService.ChangeEmail(userId, userDto.Email);
            return Mapper.Map<UserDTO>(user);
        }


        [HttpPut("/change_login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public async Task<ActionResult<UserDTO>> ChangeLogin([FromQuery]int userId, UserDTO userDto, [FromHeader] string authorization)
        {
            var changedId = GetUserIdFromToken(authorization);
            if (changedId != userId) return Unauthorized();
            try
            {
                var user = await UserService.ChangeLogin(userId, userDto.Login);
                user.Password = "hidden";
                return Mapper.Map<UserDTO>(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (NotSupportedException ex)
            {
                return Conflict(ex);
            }
        }


        [HttpPut("/change_password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public async Task<IActionResult> ChangePassword([FromQuery] int userId, UserDTO userDto, [FromHeader] string authorization)
        {
            var changedId = GetUserIdFromToken(authorization);
            if (changedId != userId) return Unauthorized();
            
            var exist = await UserService.Get(userId);
            if (exist == null) return NotFound();

            await UserService.ChangePassword(userId, userDto.Password);
            return Ok();
        }
       
      
        [HttpPost("/extendRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public async Task<ActionResult<UserDTO>> ExtendRole(int userId, [FromForm] string inpOrPass, [FromForm] bool isIpn)
        {
            var result = await UserService.ExtendRole(userId, inpOrPass, isIpn);
            if (result == null) return NotFound();
            result.Password = "hidden";
            return Mapper.Map<UserDTO>(result);
        }
        #endregion

        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "User,SuperUser,NewsAndEvents,Moderator,ApplicationAdmin,UserManager")]
        public override async Task<ActionResult> Delete(int id)
        {
            Claim i = HttpContext.User.Claims.FirstOrDefault(s => s.Type == "person/user/identificate");
            if(i==null) return Unauthorized();
            if (string.IsNullOrEmpty(i.Value)) return Unauthorized();
            int deleted = int.Parse(i.Value);
            if(deleted!=id) return Unauthorized();
            return await base.Delete(id);
        }

        private int GetUserIdFromToken(string authorization)
        {
            //cut start "Bearer "
            var stream = authorization.Substring(7);
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
            
            //Get claim with id
            Claim id = tokenS?.Claims.FirstOrDefault(s => s.Type == "person/user/identificate");
            if (id == null) return 0;
            string userTokenId = id.Value;
            try
            {
                int userId = Int32.Parse(userTokenId);
                return userId;
            }
            catch
            {
                return 0;
            }
        }


    }


}