using Sealed.Domain.Models;

namespace Sealed.Domain.DTOs
{
    public static class MapperExtensions
    {
        public static KeyDTO ToDTO(this Key key)
        {
            KeyDTO keyDTO = new KeyDTO()
            {
                Code = key.Code.ToString()
            };

            return keyDTO;
        }

        public static KeyPairDTO ToDTO(this KeyPair keyPair)
        {
            KeyPairDTO codePairDTO = new KeyPairDTO()
            {
                PrivateKey = keyPair.PrivateKey.ToDTO(),
                PublicKey = keyPair.PublicKey.ToDTO()
            };

            return codePairDTO;
        }
    }
}
