using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;
namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        ProductCategoryBUS cateBUS = new ProductCategoryBUS();
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] ProductCategoryModel model)
        {
            try
            {
                int result = cateBUS.Create(model);
                return result >= 1 ? Ok("Thêm thành công"):BadRequest("Thêm thất bại");

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] ProductCategoryModel model)
        {
            try
            {
                int result = cateBUS.Update(model);
                return result >= 1 ? Ok("Thêm thành công !") : BadRequest("Thêm thất bại !");
            }catch(Exception ex) { 
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]

        public IActionResult Delete(int id)
        {
            try
            {
                int result = cateBUS.Delete(id);
                return result >= 1 ? Ok("Xóa thành công !") : BadRequest("Xóa thất bại !");
            }catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
