using Sealed.Domain.Models;
using static Sealed.Domain.Enums;

namespace Sealed.Application.Interfaces
{
    public interface IKeyService
    {
        Key? GetKeyFromCode(string code);

        KeyPair CreateKeyPair();

        KeyTypeEnum? GetKeyType(string keyCode);

        Key? GetPublicKeyForPrivateKey(string privateKey);
    }
}