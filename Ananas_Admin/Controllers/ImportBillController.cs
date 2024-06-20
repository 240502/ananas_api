using Businesss;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportBillController : ControllerBase
    {
        ImportBillBUS impBUS = new ImportBillBUS();
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] ImportBillModel imp)
        {
            return impBUS.Create(imp) >=1 ? Ok("Thêm thành công"):BadRequest("Thêm thât bại");
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] ImportBillModel imp)
        {
            return impBUS.Update(imp) >= 1 ? Ok("Sửa thành công") : BadRequest("Sửa thất bại"); 
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return impBUS.Delete(id) >=1 ? Ok("Xóa thành công"):BadRequest("Xóa thất bại");
        }
        [Route("getById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            ImportBillModel imp = impBUS.GetById(id);

            return imp != null ? Ok(imp):NotFound();
        }
    }
}
