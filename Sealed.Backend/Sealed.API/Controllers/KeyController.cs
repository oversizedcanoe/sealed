using Microsoft.AspNetCore.Mvc;
using Sealed.API.Validation;
using Sealed.Application.Interfaces;
using Sealed.Domain.DTOs;
using Sealed.Domain.Models;
using static Sealed.Domain.Enums;

namespace Sealed.API.Controllers
{
    public class KeyController : BaseController
    {
        private readonly ILogger<KeyController> _logger;
        private readonly IKeyService _keyService;

        public KeyController(ILogger<KeyController> logger, IKeyService keyService)
        {
            this._logger = logger;
            this._keyService = keyService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<KeyPairDTO> CreateKeyPair()
        {
            var keyPair = this._keyService.CreateKeyPair();

            return Created(uri: string.Empty, keyPair.ToDTO());
        }

        [HttpGet("{key}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KeyTypeEnum> GetKeyType([IsGuid] string key)
        {
            KeyTypeEnum? keyType = this._keyService.GetKeyType(key);

            if (keyType == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(keyType);
            }
        }

        [HttpGet("{privateKey}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KeyDTO> GetPublicKey([IsGuid] string privateKey)
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