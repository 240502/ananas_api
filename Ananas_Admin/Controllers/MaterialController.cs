using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        MaterialBUS materialBUS = new MaterialBUS();
        [Route("getAll")]
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                List<MaterialModel> list = materialBUS.getAll();
                return list != null ? Ok(list):NotFound();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
