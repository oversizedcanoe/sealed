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

        [HttpGet]
        public string GetPrivateCode()
        {
            // Todo skip logic for now just testing
            string code = Guid.NewGuid().ToString();

            return "hello";
        }
    }
}