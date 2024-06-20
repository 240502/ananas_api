using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Runtime;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UsersController : ControllerBase
    {
        UsersBUS usersBUS = new UsersBUS();

        [Route("getTotalUser")]
        [HttpGet]
        public IActionResult getTotalUser()
        {
            try
            {
                int result = usersBUS.GetTotalUser();
                return Ok(result);
            }catch (Exception ex)
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
                UsersModel model = usersBUS.getById(id);
                return model !=null? Ok(model): NotFound();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("searchUser")]
        [HttpPost]
        public IActionResult searchUser([FromBody] Dictionary<string, object> formData)

        {
            try
            {
                int? pageIndex = null;
                int? pageSize = null;
                string  value = "";
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
                List<UsersModel> list = usersBUS.searchUser(pageIndex, pageSize, value, out total);
                return list != null ? Ok(new { data = list, pageIndex = pageIndex, pageSize = pageSize, totalItems = total, value = value }) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("searchCustomer")]
        [HttpPost]
        public IActionResult searchCustomer([FromBody] Dictionary<string, object> formData)

        {
            try
            {
                int? pageIndex = null;
                int? pageSize = null;
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
                List<UsersModel> list = usersBUS.searchCustomer(pageIndex, pageSize, value, out total);
                return list != null ? Ok(new { data = list, pageIndex = pageIndex, pageSize = pageSize, totalItems = total, value = value }) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("getList")]
        [HttpPost]
        public IActionResult getList([FromBody] Dictionary<string,object> formData)

        {
            try
            {
                int? pageIndex = null;
                int? pageSize = null;
                int role_id = 0;
                if (formData.ContainsKey("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
                {
                    pageIndex = int.Parse(formData["pageIndex"].ToString());
                }
                if (formData.ContainsKey("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
                {
                    pageSize = int.Parse(formData["pageSize"].ToString());

                }
                if (formData.ContainsKey("role_id") && !string.IsNullOrEmpty(formData["role_id"].ToString()))
                {
                    role_id = int.Parse(formData["role_id"].ToString());

                }
                int total = 0;
                List<UsersModel> list = usersBUS.getList(pageIndex, pageSize,role_id,out total);
                return list != null ? Ok(new { data = list,pageIndex = pageIndex, pageSize= pageSize,totalItems = total ,role_id = role_id}) : NotFound();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] UsersModel model)
        {
            try
            {
                int result = usersBUS.Create(model);
                return result >= 1 ? Ok("Thêm thành công !") : BadRequest("Thêm thất bại !");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = usersBUS.Delete(id);
                return result >= 1 ? Ok("Xóa thành công !"):BadRequest("Xóa thất bại !");

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] UsersModel model)
        {
            try
            {
                int result = usersBUS.Update(model);
                return result >= 1 ? Ok("Sửa thành công !") : BadRequest("Sửa thất bại !");

            }catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
