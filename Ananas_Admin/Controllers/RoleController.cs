using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleBUS roleBUS = new RoleBUS();
        [Route("getById")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                RoleModel role = roleBUS.getById(id);
                return role != null ? Ok(role):NotFound();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
