using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;
using Microsoft.AspNetCore.Authorization;
namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderBUS odBUS = new OrderBUS();


        [Route("getListOrderWaitConfirmation")]
        [HttpPost]
        [Authorize]


        public IActionResult getListOrderWaitConfirmation([FromBody] Dictionary<string,object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
                int status_id = 0;
                if (formData.ContainsKey("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.ContainsKey("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());

                }
                if (formData.ContainsKey("status_id") && !string.IsNullOrEmpty(formData["status_id"].ToString()))
                {
                    status_id = int.Parse(formData["status_id"].ToString());

                }
                int total = 0;
                List<OrderModel> list = odBUS.getListOrderWaitConfirmation(pageIndex, pageSize, status_id, out total);
                return list != null ? Ok(new { data = list,pageIndex = pageIndex, pageSize = pageSize, status_id=status_id, totalItems = total }):NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("search")]
        [HttpPost]
        [Authorize]


        public IActionResult search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                int? pageIndex = 0;
                int? pageSize = 0;
                string value = "";
                int status_id = 0;
                if (formData.ContainsKey("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.ContainsKey("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());

                }
                if (formData.ContainsKey("status_id") && !string.IsNullOrEmpty(formData["status_id"].ToString()))
                {
                    status_id = int.Parse(formData["status_id"].ToString());

                }
                if (formData.ContainsKey("value") && !string.IsNullOrEmpty(formData["value"].ToString()))
                {
                    value = formData["value"].ToString();

                }
                int total = 0;
                List<OrderModel> list = odBUS.search(pageIndex, pageSize,value, status_id, out total);
                return list != null ? Ok(new { data = list, pageIndex = pageIndex, pageSize = pageSize,value=value, status_id = status_id, totalItems = total }) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("countOrderYear")]
        [HttpGet]
        [Authorize]

        public IActionResult CountOrderYear()
        {
            try
            {
                List<OrderStatisticsModel> arr = odBUS.CountOrderYear();
                return arr != null ? Ok(arr) : NotFound() ;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("getTotalOrder")]
        [HttpGet]
        [Authorize]

        public IActionResult GetTotalOrderToday()
        {
            try
            {
                Dictionary<string,int> result = odBUS.GetTotalOrderToday();
                return Ok(new {totalOrder =  result["totalOrder"],totalPrice = result["totalPrice"] });
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [Route("RevenueByMonth")]
        [HttpPost]
        [Authorize]
        public IActionResult RevenueStatistics([FromBody] Dictionary<string,object> formData)
        {
            try
            {
                int? to_month = null;
                int? fr_month = null;
                if(formData.Keys.Contains("fr_month") && !string.IsNullOrEmpty(formData["fr_month"].ToString()))
                {
                    fr_month = int.Parse(formData["fr_month"].ToString());
                }
                if (formData.Keys.Contains("to_month") && !string.IsNullOrEmpty(formData["to_month"].ToString()))
                {
                    to_month = int.Parse(formData["to_month"].ToString());
                }
                List<Dictionary<string, int>> result = odBUS.RevenueStatistics(fr_month, to_month);
                return result != null ? Ok(result):BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("create")]
        [HttpPost]

        public IActionResult Create([FromBody] OrderModel order)
        {
            try
            {
                var result = odBUS.Create(order);
                return result >= 1 ? Ok(result) :BadRequest();

            }catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }

        }
        [Route("update")]
        [HttpPut]
        [Authorize]

        public IActionResult Update([FromBody] OrderModel order)
        {
            return odBUS.Update(order) >= 1 ? Ok("Sửa thành công"):BadRequest("Sửa thất bại");
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return odBUS.Delete(id) >=1 ? Ok("Xóa thành công"):BadRequest("Xóa thất bại");
        }

        [Route("cancel")]
        [HttpPut]
        public IActionResult Cancel(int id)
        {
            try
            {
                int result = odBUS.Cancel(id);
                return result >= 1 ? Ok():BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
