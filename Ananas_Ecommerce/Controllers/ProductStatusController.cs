using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;
namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStatusController : ControllerBase
    {
        ProductStatusBUS statusBUS = new ProductStatusBUS();
        [Route("getById")]
        [HttpGet] 
        public IActionResult getById(int id)
        {
            try
            {
                ProductStatusModel model = statusBUS.getById(id);
                return model !=null ? Ok(model) : NotFound();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("getAll")]
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                List<ProductStatusModel>model = statusBUS.getAll();
                return model != null ? Ok(model) : NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
