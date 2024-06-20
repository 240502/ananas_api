using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {   
        UsersBUS us = new UsersBUS();
        [Route("Login")]
        [HttpPost]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var result = us.Login(model.userName, model.password);
            try
            {

                return result == null ? BadRequest(new { message = "Tên đăng nhập hoặc mật khẩu không đúng" }) :
                                        Ok(new {  passowrd="", role = result.role_id, id = result.id, us_name = result.us_name, province = result.province, district = result.district, ward = result.ward, email = result.email , phone_number = result.phone_number,token = result.token }) ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
