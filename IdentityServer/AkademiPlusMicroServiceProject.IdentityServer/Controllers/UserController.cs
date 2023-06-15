using AkademiPlusMicroServiceProject.IdentityServer.DTOs;
using AkademiPlusMicroServiceProject.IdentityServer.Models;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.IdentityServer.Controllers
{
    [Route("api/[controller]")]
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
    }
}
