using e_shop.DbContexts;
using e_shop.Entities;
using e_shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly EShopContext _context;

        public PaymentDetailController(EShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListPaymentDetailDTO>>> GetPaymentDetails()
        {
            var paymentDetail = await _context.PaymentDetails.
                Select(p => new ListPaymentDetailDTO(p)).ToListAsync();

            return paymentDetail;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentDetailById(int id)
        {
            var paymentDetail = await _context.PaymentDetails.
                FirstOrDefaultAsync(o => o.PaymentDetailId == id);

            return paymentDetail == null ? NotFound() : Ok(new ListPaymentDetailDTO(paymentDetail));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> CreatePaymentDetails(CreatePaymentDetailDTO paymentDetail)
        {
            if (!ModelState.IsValid) return BadRequest();

            var newPayment = new PaymentDetail
            {
                UserId = paymentDetail.UserId,
                CardOwnerName = paymentDetail.CardOwnerName,
                Email = paymentDetail.Email,
                Address = paymentDetail.Address,
                CardNumber = paymentDetail.CardNumber,
                ExpirationDate= paymentDetail.ExpirationDate,
                SecurityCode = paymentDetail.SecurityCode

            };

            await _context.PaymentDetails.AddAsync(newPayment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentDetailById), new { id = newPayment.PaymentDetailId }, paymentDetail);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePaymentDetails(int id, UpdatePaymentDetailDTO paymentDetail)
        {
            if (id != paymentDetail.PaymentId) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var paymentDB = _context.PaymentDetails.Find(id);

            paymentDB.CardOwnerName = paymentDetail.CardOwnerName;
            paymentDB.Email = paymentDetail.Email;
            paymentDB.Address = paymentDetail.Address;
            paymentDB.CardNumber = paymentDetail.CardNumber;
            paymentDB.ExpirationDate = paymentDetail.ExpirationDate;
            paymentDB.SecurityCode = paymentDetail.SecurityCode;


            _context.Entry(paymentDB).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> DeleteFromPaymentDetais(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetail == null)
                return NotFound();

            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.PaymentDetailId == id);
        }
    }
}
