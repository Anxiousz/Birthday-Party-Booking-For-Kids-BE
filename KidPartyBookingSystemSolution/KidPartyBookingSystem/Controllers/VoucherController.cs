using BusinessObjects;
using BusinessObjects.Request;
using BussinessObjects;
using BussinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Impl;

namespace KidPartyHostingSystemAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Roles ="3")]
    public class VoucherController : ControllerBase
    {
        private IVoucherService _voucher;
        public VoucherController(IVoucherService voucher)
        {
            _voucher = voucher;
        }

        [HttpGet]
        public IActionResult GetPartyHost()
        {
            var voucher = _voucher.GetVoucher();
            if (voucher != null)
            {
                return Ok(voucher);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetVouchetById(int id)
        {
            var voucher = _voucher.GetVoucherById(id);
            if (voucher != null)
            {
                return Ok(voucher);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateVoucher([FromBody] RequestVoucherDTO request)
        {
            if (request == null)
            {
                return BadRequest("The field not empty");
            }
            int reissuedBy = request.ReissuedBy ?? 0;
            bool checkExisted = _voucher.checkVoucherExistedByReissued(reissuedBy);
            if (checkExisted != true)
            {
                RequestVoucherDTO createVoucher = _voucher.CreateVoucher(request);
                return Ok(createVoucher);
            }
            return Conflict("The voucher is existed");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVoucher(int id)
        {
            Voucher checkExisted = _voucher.checkVoucherExistedByID(id);
            if (checkExisted != null)
            {
                bool deleteAccount = _voucher.DeleteVoucher(id);
                return Ok("Delete " + checkExisted.VoucherId + " successfully");
            }
            return NotFound("The voucher not found");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVoucher(int id, [FromBody] RequestVoucherDTO request)
        {
            if (request == null)
            {
                return BadRequest("The request body is empty");
            }

            Voucher existedVoucher = _voucher.checkVoucherExistedByID(id);
            if (existedVoucher == null)
            {
                return NotFound("Voucher not found");
            }
            existedVoucher.FromDate = request.FromDate;
            existedVoucher.ToDate = request.ToDate;
            existedVoucher.Expired = request.Expired;
            existedVoucher.ReissuedBy = request.ReissuedBy;

            Voucher updatedVoucher = _voucher.UpdateVoucher(existedVoucher);

            if (updatedVoucher != null)
            {
                return Ok("Voucher updated successfully");
            }
            else
            {
                return StatusCode(500, "Failed to update the voucher");
            }
        }

        [HttpGet("search/{context}")]
        public IActionResult searchVoucher(string context)
        {
            List<Voucher> searchVoucher = _voucher.searchVoucher(context);
            return Ok(searchVoucher);
        }
    }
}
