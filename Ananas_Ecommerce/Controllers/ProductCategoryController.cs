using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business;
using Model;
using System.Linq.Expressions;
using Microsoft.SqlServer.Server;
namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        ProductCategoryBUS cateBUS = new ProductCategoryBUS();
        [Route("getAll")]
        [HttpGet]
        public IActionResult getAll()
        {
            try{
                List<ProductCategoryModel> list = cateBUS.getAll();
                return list != null ? Ok(list) : NotFound();

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("getList")]
        [HttpPost]
        public IActionResult getList([FromBody] Dictionary<string,object> formData) {
            try
            {
                int pageIndex = 0;
                int pageSize = 0; 
                if (formData.ContainsKey("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.ContainsKey("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());

                }
                int total = 0;
                List<ProductCategoryModel> list = cateBUS.getList(pageIndex,pageSize,out total);
                return list != null ? Ok(new { data = list,totalItems=total,pageIndex = pageIndex,pageSize=pageSize }) : NotFound();    
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        [Route("search")]
        [HttpPost]
        public IActionResult search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int pageIndex = 0;
                int pageSize = 0;
                string value = "";
                if (formData.ContainsKey("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
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
                List<ProductCategoryModel> list = cateBUS.search(pageIndex, pageSize,value, out total);
                return list != null ? Ok(new { data = list, totalItems = total, pageIndex = pageIndex, pageSize = pageSize }) : NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }
        [Route("getById")]
        [HttpGet]
        public IActionResult getById(int id)
        {
            try
            {
                ProductCategoryModel proCate = cateBUS.getById(id);
                return proCate != null ? Ok(proCate) : NotFound();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
