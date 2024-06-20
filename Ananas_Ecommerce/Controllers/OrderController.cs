using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;
namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderBUS odBUS = new OrderBUS();
        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                OrderModel order = odBUS.GetById(id);
                return order != null ? Ok(order) : NotFound();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("GetByIdAndPhoneOrEmail")]
        [HttpGet]
        public IActionResult GetByIdAndPhoneOrEmail(int id,string option) {
            try
            {
                OrderModel order = odBUS.getOrderByIdAndPhoneOrEmail(id, option);
                return order != null ? Ok(order) : NotFound();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
