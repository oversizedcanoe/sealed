using Sealed.Application.Interfaces;
using Sealed.Database;
using Sealed.Domain.DTOs;
using Sealed.Domain.Models;

namespace Sealed.Application.Services
{
    public class UserEntryService : IUserEntryService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IKeyService _keyService;

        public UserEntryService(DatabaseContext databaseContext, IKeyService keyService)
        {
            this._databaseContext = databaseContext;
            this._keyService = keyService;
        }

        public IEnumerable<UserEntry> GetUserEntries(string privateKey)
        {
            Key? key = this._keyService.GetKeyFromCode(privateKey);

            IEnumerable<UserEntry> entries = Enumerable.Empty<UserEntry>();

            if (key != null)
            {
                entries = this._databaseContext.UserEntries.Where(ue => ue.PrivateKeyId == key.KeyId).ToList();
            }

            return entries;
        }

        public UserEntryDTO? AddUserEntry(string publicKey, string text)
        {
            Key? privateKey = this._keyService.GetPrivateKeyForPublicKey(publicKey);

            if (privateKey == null)
            {
                return null;
            }

            UserEntry userEntry = new UserEntry()
            {
                PrivateKeyId = privateKey.KeyId,
                EntryText = text
            };

            this._databaseContext.UserEntries.Add(userEntry);

            this._databaseContext.SaveChanges();

            return userEntry.ToDTO();
        }
    }
}
