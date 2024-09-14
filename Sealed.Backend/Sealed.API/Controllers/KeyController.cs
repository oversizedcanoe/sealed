using Microsoft.AspNetCore.Mvc;
using Sealed.Database;
using Sealed.Domain.DTOs;

namespace Sealed.API.Controllers
{
    [Route("[controller]/[action]")]
    public class KeyController : BaseController
    {
        private readonly ILogger<KeyController> _logger;
        private readonly DatabaseContext _databaseContext;

        public KeyController(ILogger<KeyController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        //[HttpGet]
        //public string GetPrivateCode()
        //{
        //    var types = _sealedContext.CodeType.ToList();

        //    // Todo skip logic for now just testing
        //    return Guid.NewGuid().ToString();
        //}
    }
}