using Sealed.Domain.Models;

namespace Sealed.Domain.DTOs
{
    public static class MapperExtensions
    {
        public static CodePairDTO ToDTO(this CodePair codePair)
        {
            CodePairDTO codePairDTO = new CodePairDTO()
            {
                PrivateCode = codePair.PrivateCode,
                PublicCode = codePair.PublicCode
            };

            return codePairDTO;
        }
    }
}
