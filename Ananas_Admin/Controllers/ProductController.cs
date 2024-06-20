using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Model;
using Businesss;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Authorization;
namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductController : ControllerBase
    {
        ProductBUS proBUS = new ProductBUS();
        List<ProductModel> product_list ;

        [Route("getTop5ProductBestSale")]
        [HttpPost]

        public IActionResult GetTop5ProductBestSale([FromBody] Dictionary<string,object> formData)
        {
            try
            {
                int month = 0;
                int year = 0;
                if (formData.Keys.Contains("month") && !string.IsNullOrEmpty(formData["month"].ToString()))
                {
                    month = int.Parse(formData["month"].ToString());
                }
              
                if (formData.Keys.Contains("year") && !string.IsNullOrEmpty(formData["year"].ToString()))
                {
                    year = int.Parse(formData["year"].ToString());
                }
                List<ProductStatistics> list = proBUS.GetTop5ProductBestSale(month,year);
                return list != null ? Ok(list) : NotFound();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("getTop5ProductBestView")]
        [HttpPost]

        public IActionResult GetTop5ProductBestView([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int month = 0;
                int year = 0;
                if (formData.Keys.Contains("month") && !string.IsNullOrEmpty(formData["month"].ToString()))
                {
                    month = int.Parse(formData["month"].ToString());
                }
            
                if (formData.Keys.Contains("year") && !string.IsNullOrEmpty(formData["year"].ToString()))
                {
                    year = int.Parse(formData["year"].ToString());
                }
                List<ProductStatistics> list = proBUS.GetTop5ProductBestView(month, year);
                return list != null ? Ok(list) : NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] ProductModel product)
        {
                int result = proBUS.Create(product);
                return result >= 1 ? Ok("Thêm thành công !"):BadRequest("Thêm thất bại");

        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return proBUS.Delete(id) >=1 ? Ok("Xóa thành công"):BadRequest("Xóa thất bại");
        }
        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] ProductModel product)
        {
            return proBUS.Update(product) >=1 ? Ok("Sửa thành công"):BadRequest("Sửa thất bại");
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string,object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
                string value = "";
                    if(formData.ContainsKey("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                    {
                        pageIndex = int.Parse(formData["pageIndex"].ToString());
                    }
                    if (formData.ContainsKey("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                    {
                        pageSize = int.Parse(formData["pageSize"].ToString());

                    }
                    if (formData.ContainsKey("value") && !string.IsNullOrEmpty(formData["value"].ToString()))
                    {
                        value = formData["value"].ToString();   
                    }
                    int total = 0;
                    product_list = proBUS.Search(pageIndex,pageSize,value,out total);
                    return product_list != null ? Ok(new { totalItems = total, data = product_list, pageIndex = pageIndex, pageSize = pageSize }):NotFound();

                

            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
