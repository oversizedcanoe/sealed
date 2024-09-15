using Sealed.Application.Interfaces;
using Sealed.Database;
using Sealed.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sealed.Application.Services
{
    public class UserEntryService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IKeyService _keyService;

        public UserEntryService(DatabaseContext databaseContext, IKeyService keyService)
        {
            this._databaseContext = databaseContext;
            this._keyService = keyService;
        }

        public IEnumerable<UserEntry> GetUserEntries(string publicKey)
        {
            Key? key = this._keyService.GetKeyFromCode(publicKey);

            IEnumerable<UserEntry> entries = Enumerable.Empty<UserEntry>();

            if (key != null)
            {
                entries = this._databaseContext.UserEntries.Where(ue => ue.PublicKeyId == key.KeyId).ToList();
            }

            return entries;
        }

        public void AddUserEntry()
        {

        }
    }
}
