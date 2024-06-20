using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingTypeController : ControllerBase
    {
        ShippingTypeBUS typeBUS = new ShippingTypeBUS();
        [Route("getList")]
        [HttpGet]
        public IActionResult getList()
        {
            try
            {
                List<ShippingTypeModel> list = typeBUS.getList();
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
                ShippingTypeModel model = typeBUS.getById(id);
                return model != null ? Ok(model) : NotFound();
            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
