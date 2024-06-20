using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;
using System.Runtime.CompilerServices;
namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        ColorBUS colorBUS = new ColorBUS();
        [Route("getById")]
        [HttpGet]
        public IActionResult getById(int id) {
            try
            {
                ColorModel colorModel = colorBUS.getById(id);
                return colorModel != null ? Ok(colorModel) : NotFound();

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("getAll")]
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                List<ColorModel>colorModel = colorBUS.getAll();
                return colorModel != null ? Ok(colorModel) : NotFound();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
