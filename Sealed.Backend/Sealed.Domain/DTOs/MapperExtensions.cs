using Sealed.Domain.Models;

namespace Sealed.Domain.DTOs
{
    public static class MapperExtensions
    {
        public static KeyPairDTO ToDTO(this KeyPair keyPair)
        {
            KeyPairDTO codePairDTO = new KeyPairDTO()
            {
                //PrivateKey = keyPair.PrivateKey.,
                //PublicKey = keyPair.PublicKey
            };

            return codePairDTO;
        }
    }
}
