using Sealed.Domain.Models;

namespace Sealed.Application.Interfaces
{
    public interface IUserEntryService
    {
        IEnumerable<UserEntry> GetUserEntries(string privateKey);
    }
}