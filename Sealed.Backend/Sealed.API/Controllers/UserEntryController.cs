using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sealed.API.Validation;
using Sealed.Application.Interfaces;
using Sealed.Domain.DTOs;

namespace Sealed.API.Controllers
{
    public class AddUserEntryRequest
    {
        public string Text { get; set; }
    }

    public class UserEntryController : BaseController
    {
        private readonly ILogger<UserEntryController> _logger;
        private readonly IUserEntryService _userEntryService;

        public UserEntryController(ILogger<UserEntryController> logger, IUserEntryService userEntryService)
        {
            this._logger = logger;
            this._userEntryService = userEntryService;
        }   

        [HttpGet("{privateKey}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UserEntryDTO>> GetUserEntries([IsGuid] string privateKey)
        {
            var userEntries = this._userEntryService.GetUserEntries(privateKey);

            return Ok(userEntries.Select(ue => ue.ToDTO()));
        }

        [EnableRateLimiting("IPAddressFixedWindowPolicy")]
        [HttpPost("{publicKey}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<UserEntryDTO?> AddUserEntry([IsGuid] string publicKey, [FromBody] AddUserEntryRequest request)
        {
            UserEntryDTO? userEntry = this._userEntryService.AddUserEntry(publicKey, request.Text);

            return Created(uri: string.Empty, userEntry);
        }
    }
}
