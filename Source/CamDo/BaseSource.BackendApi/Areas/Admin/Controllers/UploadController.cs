using BaseSource.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Areas.Admin.Controllers
{
    public class UploadController : BaseAdminApiController
    {
        [HttpPost("UploadImage")]
        [RequestSizeLimit(int.MaxValue)]
        [RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue)]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            if (image == null) return Ok(new ApiErrorResult<string>(ModelState.GetListErrors()));

            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName).ToLower();

            Directory.CreateDirectory(Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/upload/images"
            ));

            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/upload/images",
                fileName
            );

            using (var stream = System.IO.File.Create(filePath))
            {
                await image.CopyToAsync(stream);
            }

            var url = $"/upload/images/{fileName}";

            return Ok(new ApiSuccessResult<string>(url));
        }
    }
}
