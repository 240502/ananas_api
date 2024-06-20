using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;

namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        StyleBUS styleBUS = new StyleBUS();
        [Route("getShowMenu")]
        [HttpGet]
        public IActionResult getShowMenu()
        {
            try
            {
                List<StyleModel> list = styleBUS.getShowMenu();
                return list != null ? Ok(list) : NotFound();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("getAll")]
        [HttpGet]
        public IActionResult getAll()
        {
            try{
                List<StyleModel> list = styleBUS.getAll();
                return list != null ? Ok(list) : NotFound();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("getById")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                StyleModel style = styleBUS.getById(id);
                return style != null ? Ok(style) : NotFound();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
