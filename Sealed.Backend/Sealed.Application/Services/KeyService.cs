using Microsoft.EntityFrameworkCore;
using Sealed.Application.Interfaces;
using Sealed.Database;
using Sealed.Domain.Models;
using System.Text.Json;
using static Sealed.Domain.Enums;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Sealed.Application.Services
{
    public class KeyService : IKeyService
    {
        private readonly DatabaseContext _databaseContext;

        public KeyService(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        private Key? GetKeyFromCode(string code)
        {
            Guid guid = new Guid(g: code);
            
            return this._databaseContext.Keys.FirstOrDefault(k => k.Code == guid);
        }

        public KeyPair CreateKeyPair()
        {
            var publicKey = new Key()
            {
                Code = Guid.NewGuid(),
                KeyTypeId = (int)KeyTypeEnum.Public
            };

            var privateKey = new Key()
            {
                Code = Guid.NewGuid(),
                KeyTypeId = (int)KeyTypeEnum.Private
            };

            var keyPair = new KeyPair()
            {
                PublicKey = publicKey,
                PrivateKey = privateKey
            };

            _databaseContext.KeyPairs.Add(keyPair);

            _databaseContext.SaveChanges();

            return keyPair;
        }

        public KeyTypeEnum? GetKeyType(string keyCode)
        {
            Key? key = this.GetKeyFromCode(keyCode);

            if (key != null)
            {
                return (KeyTypeEnum)key.KeyTypeId;
            }
            else
            {
                return null;
            }
        }

        public Key? GetPublicKeyForPrivateKey(string privateKey)
        {
            Key? key = this.GetKeyFromCode(privateKey);

            if (key == null)
            {
                return null;
            }

            KeyPair keyPair = this._databaseContext.KeyPairs
                .Include(kp => kp.PrivateKey)
                .Include(kp => kp.PublicKey)
                .Single(kp => kp.PrivateKey == key);

            return keyPair.PublicKey;
        }
    }
}
