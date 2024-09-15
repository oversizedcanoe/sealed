using System.ComponentModel.DataAnnotations;

namespace Sealed.API.Validation
{
    public class IsGuid : ValidationAttribute
    {
        public IsGuid()
        {
            this.ErrorMessage = "Value is not a valid GUID.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }

            return Guid.TryParse(value.ToString(), out _);
        }
    }
}
