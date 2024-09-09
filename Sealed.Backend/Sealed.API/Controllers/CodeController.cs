using Microsoft.AspNetCore.Mvc;
using Sealed.Database;
using Sealed.Domain.DTOs;

namespace Sealed.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CodeController : BaseController
    {
        private readonly ILogger<CodeController> _logger;
        private readonly SealedContext _sealedContext;

        public CodeController(ILogger<CodeController> logger, SealedContext sealedContext)
        {
            _logger = logger;
            _sealedContext= sealedContext;
        }

        [HttpGet]
        public string GetPrivateCode()
        {
            var types = _sealedContext.Codetypes.ToList();

            // Todo skip logic for now just testing
            return Guid.NewGuid().ToString();
        }
    }
}