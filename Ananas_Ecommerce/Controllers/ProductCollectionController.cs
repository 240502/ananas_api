using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCollectionController : ControllerBase
    {
        ProductCollectionBUS collectionBUS = new ProductCollectionBUS();
        [Route("getAll")]
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                List<ProductCollectionModel> list = collectionBUS.getAll();
                return list != null ? Ok(list) : NotFound();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
