using Microsoft.AspNetCore.Mvc;
using Sealed.Domain.DTOs;

namespace Sealed.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CodeController : BaseController
    {
        private readonly ILogger<CodeController> _logger;

        public CodeController(ILogger<CodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPair")]
        public CodePairDTO GetPair()
        {
            // Todo skip logic for now just testing
            return new CodePairDTO()
            {
                PrivateCode = Guid.NewGuid().ToString(),
                PublicCode = Guid.NewGuid().ToString(),
            };
        }
    }
}