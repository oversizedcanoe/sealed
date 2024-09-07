namespace Sealed.Domain.Models
{
    public class CodePair
    {
        public string PrivateCode { get; private set; }
        public string PublicCode { get; private set; }

        public CodePair(string privateCode, string publicCode)
        {
            this.PrivateCode = privateCode;
            this.PublicCode = publicCode;
        }
    }
}
