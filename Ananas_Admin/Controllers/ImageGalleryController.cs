using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ImageGalleryController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        ImageGallaryBUS imageGallaryBUS = new ImageGallaryBUS(); 
        public ImageGalleryController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("Upload")]
        [HttpPost]
        public string Upload( IFormFile formFile)
        {
            try
            {
                if(formFile.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\product\\" ;
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }    
                    using(FileStream fileStream = System.IO.File.Create(path+formFile.FileName))
                    {
                        formFile.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return "//uploads/product/" + formFile.FileName;
                    }
                }
                else { return "Fail"; }
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [NonAction]
        private string GetFilePath(string ProductCode)
        {
            return _webHostEnvironment.WebRootPath + "\\uploads\\Product\\" + ProductCode;
        }

        [Route("DeleteImage")]
        [HttpGet]
        public IActionResult DeleteImage(string code)
        {
            try
            {
                string path = GetFilePath(code);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Ok(path);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //[Route("Upload")]
        //[HttpPost,DisableRequestSizeLimit]
        //public async Task<IActionResult> UpLoad(IFormFile file)
        //{
        //    try
        //    {
        //        if(file.Length > 0)
        //        {
        //            string fullPath = $"upload/{file.FileName}";
        //            using (var fileStream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(fileStream);
        //            } 
        //            return Ok(new {fullPath});
        //        }
        //        else{ return BadRequest(); }
        //    }catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [Route("Create")]
        [HttpPost]
        public IActionResult Create([FromBody] ImageGalleryModel model)
        {
            try
            {
                int result = imageGallaryBUS.Create(model);
                return result >= 1 ? Ok("Thêm thành công"):BadRequest("Thêm thất bại");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
