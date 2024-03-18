using BusinessObjects;
using BusinessObjects.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Authorize(Roles ="4")]
    [Route("api/v1/[controller]/[action]")]
    public class TransactionController : ControllerBase
    {
        private ITransactionBookingService _transactionService;
        public TransactionController(ITransactionBookingService transactionService)
        {
            _transactionService = transactionService;
        }


        [HttpGet]
        public IActionResult ViewTransaction(int id)
        {
            try
            {

                List<Booking>? transactionDTO =  _transactionService.GetTransactionById(id);

                if (transactionDTO == null)
                {
                    return BadRequest($"Transaction with id = {id} doesn't exist");
                }

                return Ok(transactionDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return BadRequest("Invalid Request");
            }
        }

    }
}
