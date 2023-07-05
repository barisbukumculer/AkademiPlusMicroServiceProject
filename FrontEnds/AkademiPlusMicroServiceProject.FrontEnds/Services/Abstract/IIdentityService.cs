using AkademiPlusMicroServiceProject.FrontEnds.Models;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.FrontEnds.Services.Abstract
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);
    }
}
