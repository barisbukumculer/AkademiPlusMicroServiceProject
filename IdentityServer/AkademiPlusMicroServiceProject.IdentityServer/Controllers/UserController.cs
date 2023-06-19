using AkademiPlusMicroServiceProject.IdentityServer.DTOs;
using AkademiPlusMicroServiceProject.IdentityServer.Models;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace AkademiPlusMicroServiceProject.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            var user = new ApplicationUser()
            {
                UserName = signUpDTO.Username,
                Email = signUpDTO.Email,
                City = signUpDTO.City,
                Country = signUpDTO.Country,

            };
            var result=await _userManager.CreateAsync(user,signUpDTO.Password);
            if(!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(400,result.Errors.Select(x=>x.Description).ToList()));
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userclaimID = User.Claims.FirstOrDefault(x=>x.Type==JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userclaimID.Value);
            return Ok(new {Id=user.Id,username=user.UserName,email=user.Email,city=user.City,country=user.Country});

        }
    }
}
