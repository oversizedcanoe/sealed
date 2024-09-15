using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sealed.API.Validation;
using Sealed.Domain.DTOs;

namespace Sealed.API.Controllers
{
    public class UserEntryController : BaseController
    {
        private readonly ILogger<UserEntryController> _logger;

        public UserEntryController(ILogger<UserEntryController> logger)
        {
            this._logger = logger;
        }

        [HttpGet("{privateKey}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserEntryDTO> GetUserEntries([IsGuid] string privateKey)
        {
            Key? publicKey = this._keyService.GetPublicKeyForPrivateKey(privateKey);

            if (publicKey == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(publicKey.ToDTO());
            }
        }
    }
}
