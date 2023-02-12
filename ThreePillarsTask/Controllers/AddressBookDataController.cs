using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Project.Services.Handler;
using Project.Services.ModalServices;
using Project.Services.Helper.Exceptions;

namespace ThreePillarsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressBookDataController : Controller
    {
        private readonly AddressBookCommand _Data;

        #region constractor
        public AddressBookDataController(AddressBookCommand Data)
        {
            _Data = Data;
     
        }
        #endregion


        #region API
        [HttpPost]
        public async Task<IActionResult> post(AddressBookModel model)
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
        public async Task<IActionResult> put(AddressBookModel model)
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
                var model = await _Data.Get(id).ConfigureAwait(false);
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AddressBookModel>> Get()
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
        public async Task<ActionResult<AddressBookModel>> Get(int id)
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


        [HttpGet, Route("/api/address/filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AddressBookModel>> FilterData([FromQuery] DateTime? fm, DateTime? to, int jobid = 0, int depid = 0)
        {
            try
            {
                var data = await _Data.FilterData(jobid,depid,fm,to).ConfigureAwait(false);
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
