using Microsoft.AspNetCore.Mvc;
using Sealed.Database;
using Sealed.Domain.DTOs;
using Sealed.Domain.Models;
using static Sealed.Domain.Enums;

namespace Sealed.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class KeyController : BaseController
    {
        private readonly ILogger<KeyController> _logger;
        private readonly DatabaseContext _databaseContext;
        
        public KeyController(ILogger<KeyController> logger, DatabaseContext databaseContext)
        {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        public string GetPrivateKey()
        {
            // Test Code

            Key publicKey = new Key()
            {
                Code = Guid.NewGuid(),
                KeyTypeId = (int)KeyTypeEnum.Public
            };

            Key privateKey = new Key()
            {
                Code = Guid.NewGuid(),
                KeyTypeId = (int)KeyTypeEnum.Private
            };

            _databaseContext.Keys.Add(publicKey);
            _databaseContext.Keys.Add(privateKey);

            _databaseContext.SaveChanges();

            _databaseContext.KeyPairs.Add(new KeyPair()
            {
                PublicKey = publicKey,
                PrivateKey = privateKey
            });

            _databaseContext.SaveChanges();

            return privateKey.Code.ToString();
        }
    }
}