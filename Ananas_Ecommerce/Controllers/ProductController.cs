using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Businesss;
using Microsoft.SqlServer.Server;
namespace API_ananas_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {   
        ProductBUS proBUS = new ProductBUS();
        [Route("getById")]
        [HttpGet]
        public IActionResult GetById(int id) {
            try
            {
                ProductModel product = proBUS.GetById(id);
                return product!=null ? Ok(product) : NotFound();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("getByCateId")]
        [HttpGet]
        public IActionResult GetByCateId(int cateId)
        {
            try
            {
                List<ProductModel>product = proBUS.GetByCateId(cateId);
                return product != null ? Ok(product) : NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("getRelatedProduct")]
        [HttpPost]
        public IActionResult getRelatedProduct([FromBody] Dictionary<string, object> data)
        {
            try
            {
                int? cateId = null;
                int? collectionId = null;
                int? styleId = null;
                string? gender = null;
                int id = 0;
                if (data.ContainsKey("cateId") && !string.IsNullOrEmpty(data["cateId"].ToString()))
                {
                    cateId = int.Parse(data["cateId"].ToString());
                }
                if (data.ContainsKey("collectionId") && !string.IsNullOrEmpty(data["collectionId"].ToString()))
                {
                    collectionId = int.Parse(data["collectionId"].ToString());
                }
                if (data.ContainsKey("styleId") && !string.IsNullOrEmpty(data["styleId"].ToString()))
                {
                    styleId = int.Parse(data["styleId"].ToString());
                }

                if (data.ContainsKey("id") && !string.IsNullOrEmpty(data["id"].ToString()))
                {
                    id = int.Parse(data["id"].ToString());
                }

                if (data.ContainsKey("gender") && !string.IsNullOrEmpty(data["gender"].ToString()))
                {
                    gender = data["gender"].ToString();

                }
                List<ProductModel> list = proBUS.getRelatedProduct(cateId,collectionId,styleId,gender, id);
                return list != null ? Ok(list):NotFound();


            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        [Route("getList")]
        [HttpPost]
        public IActionResult GetList([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
                string gender = "" ;
                int cate = 0;
                int startPrice = 0;
                int endPrice = 0;

                if (formData.ContainsKey("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.ContainsKey("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());

                }
                if (formData.ContainsKey("cate") && !string.IsNullOrEmpty(formData["cate"].ToString()))
                {
                    cate = int.Parse(formData["cate"].ToString());

                }
                if (formData.ContainsKey("startPrice") && !string.IsNullOrEmpty(formData["startPrice"].ToString()))
                {
                    startPrice = int.Parse(formData["startPrice"].ToString());

                }
                if (formData.ContainsKey("endPrice") && !string.IsNullOrEmpty(formData["endPrice"].ToString()))
                {
                    endPrice = int.Parse(formData["endPrice"].ToString());

                }
                if (formData.ContainsKey("gender") && !string.IsNullOrEmpty(formData["gender"].ToString()))
                {
                    gender = formData["gender"].ToString();
                }
                int total = 0;
                List<ProductModel> products = proBUS.GetList(pageIndex,pageSize,gender,cate, startPrice, endPrice, out total);
                return products != null ? Ok(new { pageIndex = pageIndex, pageSize = pageSize, totalItems = total,data = products,gender=gender,cate_id = cate, startPrice = startPrice, endPrice= endPrice }) : NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("Search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
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
                List<ProductModel> products = proBUS.Search(pageIndex, pageSize, value,out total);
                return products != null ? Ok(new { pageIndex = pageIndex, pageSize = pageSize, totalItems = total, data = products, gender = value }) : NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
