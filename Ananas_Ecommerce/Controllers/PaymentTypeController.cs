using Business;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        PaymentTypeBUS typeBUS = new PaymentTypeBUS();
        [Route("getList")]
        [HttpGet]
        public IActionResult getList()
        {
            try
            {
                List<PaymentTypeModel> list = typeBUS.getList();
                return list != null ? Ok(list) : NotFound();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
