using AkademiPlusMicroServiceProject.PhotoStock.DTOs;
using AkademiPlusMicroServiceProject.Shared.ControllerBases;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo,CancellationToken cancellationToken)
        {
            if (photo != null & photo.Length>0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/photos",photo.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);
                var returnPath = photo.FileName;
                photoDTO photoDTO = new photoDTO()
                {
                    Url = returnPath
                };
                return CreateActionResultInstance(Response<photoDTO>.Success(200,photoDTO));
            }
            else
            {
                return CreateActionResultInstance(Response<photoDTO>.Fail(400,"Fotoğraf Bulunamadı!"));
            }
        }
    }
}
