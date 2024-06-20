using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;

namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        List<MenuModel> menus;
        MenuBUS menuBUS = new MenuBUS();
        [Route("getAll")]
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                menus = menuBUS.getAll();
                return menus != null ? Ok(menus) : NotFound();

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
