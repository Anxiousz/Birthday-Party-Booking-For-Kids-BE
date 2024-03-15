using BusinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace KidPartyBookingSystem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private IFeedBackService _feedbackService;
        public FeedbackController(IFeedBackService feedbackService)
        {
            _feedbackService = feedbackService;
        }


        [HttpGet]
        public async Task<IActionResult> ViewFeedback(int feedbackId)
        {
            try
            {
                var feedback = await _feedbackService.GetFeedbackById(feedbackId);

                if (feedback == null)
                {
                    return BadRequest($"Feedback with id = {feedbackId} doesn't exist");
                }

                return Ok(feedback);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return BadRequest("Invalid Request");
            }
        }

        [HttpPost]
        [Authorize(Roles = "4")]
        [Route("Comment")]
        public async Task<IActionResult> Comment(RequestFeedbackDTO feedbackDTO)
        {
            try
            {
                var status = await _feedbackService.CreateFeedback(feedbackDTO);
                if (!status)
                {
                    return BadRequest($"Failed to comment feedback");
                }

                return Ok("Comment feedback successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return BadRequest("Invalid Request");
            }
        }

        [HttpPost]
        [Authorize(Roles = "4")]
        [Route("Rate")]
        public async Task<IActionResult> Rate(RequestFeedbackDTO feedbackDTO)
        {
            try
            {
                var status = await _feedbackService.CreateFeedback(feedbackDTO);
                if (!status)
                {
                    return BadRequest($"Failed to rate feedback");
                }

                return Ok("Rate feedback successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return BadRequest("Invalid Request");
            }
        }
    }
}
