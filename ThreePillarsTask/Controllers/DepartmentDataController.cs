using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Services.Handler;
using Project.Services.Helper.Exceptions;
using Project.Services.ModalServices;

namespace ThreePillarsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentDataController : Controller
    {
        private readonly DepartmentCommand _Data;

        #region constractor
        public DepartmentDataController(DepartmentCommand Data)
        {
            _Data = Data;
        }
        #endregion


        #region API
        [HttpPost]
        public async Task<IActionResult> post(DepartmentDataModel model)
        {
            try
            {
                var retdata = await _Data.Insert(model);
                var isSuccess = retdata != "-1";
                return Ok(new { success = isSuccess, id = retdata.Substring(1) });

            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, BadRequest().StatusCode);
            }
        }

        [HttpPut]
        public async Task<IActionResult> put(DepartmentDataModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var retdata = await _Data.Update(model);
                var isSuccess = retdata != "-1";
                return Ok(new { success = isSuccess, id = retdata.Substring(1) });
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, BadRequest().StatusCode);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var model = await _Data.getdatabyid(id).ConfigureAwait(false);
                if (model == null) throw new Exception("id is incorrect");
                var retdata = await _Data.Delete(model);
                var isSuccess = retdata != "-1";
                return Ok(new { success = isSuccess, id = retdata.Substring(1) });


            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, BadRequest().StatusCode);
            }
        }

     
        [HttpGet]
        public async Task<ActionResult<DepartmentDataModel>> Get()
        {
            try
            {
                var data = await _Data.GetAll().ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, BadRequest().StatusCode);
            }
        }
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<DepartmentDataModel>> Get(int id)
        {
            try
            {
                var data = await _Data.Get(id).ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message, BadRequest().StatusCode);
            }
        }

        #endregion
    }
}
