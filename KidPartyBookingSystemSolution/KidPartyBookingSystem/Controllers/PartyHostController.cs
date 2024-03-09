using BusinessObjects;
using BusinessObjects.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Impl;

namespace KidPartyBookingSystem.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "3")]
    public class PartyHostController : ControllerBase
    {
        private IPartyHostService _partyHostService;
        private IConfigService _configService;
        public PartyHostController(IPartyHostService partyHostService, IConfigService configService)
        {
            _partyHostService = partyHostService;
            _configService = configService;
        }

        [HttpGet("{id}")]
        public IActionResult GetPartyHostByID(int id)
        {
            PartyHost checkExisted = _partyHostService.checkPartyHostExistedByID(id);
            if (checkExisted != null)
            {
                return Ok(checkExisted);
            }
            return NotFound("The user not found");
        }

        [HttpPut]
        public IActionResult UpdatePartyHost(RequestUpdatePartyHostDTO request)
        {
            PartyHost checkExisted = _partyHostService.checkPartyHostExistedByID(request.PartyHostId);
            if (checkExisted != null)
            {
                RequestUpdatePartyHostDTO update = _partyHostService.UpdatePartyHost(request);
                return Ok(update);
            }
            return NotFound("The user not found");
        }
    }
}
