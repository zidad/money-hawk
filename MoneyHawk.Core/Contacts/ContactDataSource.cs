using System.Collections.Generic;
using System.Linq;
using System;

namespace MoneyHawk.Core
{
    /// <summary>
    /// Get all contacts	GET	/api/v1.0/contacts.xml
    /// Get contact	GET	/api/v1.0/contacts/:id.xml
    /// Create new contact	POST	/api/v1.0/contacts.xml
    /// Update contact	PUT	/api/v1.0/contacts/:id.xml
    /// Delete contact	DELETE	/api/v1.0/contacts/:id.xml
    /// Get list of contacts for syncing	GET	/api/v1.0/contacts/sync_list_ids.xml
    /// Get specified contacts for syncing	POST	/api/v1.0/contacts/sync_fetch_ids.xml
    /// </summary>
    public class ContactDataSource : DataSource<Contact>
    {
        public ContactDataSource(IMoneyBirdApi api) : base(api)
        {
        }

        /// Get all contacts GET /api/v1.0/contacts.xml
        public override IEnumerable<Contact> GetAll()
        {
            return api.Get<List<Contact>>("contacts.xml");
        }
    }
}