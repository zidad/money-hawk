using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyHawk.Core
{
    /// <summary>
    /// https://developer.moneybird.com/api/contacts/
    /// /contacts	GET	List all contacts
    /// /contacts/synchronization GET List all ids and versions
    /// /contacts/synchronization POST    Fetch contacts with given ids
    /// /contacts/:id GET Get contact
    /// /contacts/customer_id/:customer_id GET Get contact by customer id
    /// /contacts POST    Create a new contact
    /// /contacts/:id PATCH   Update a contact
    /// /contacts/:id DELETE  Delete a contact
    /// /contacts/:contact_id/notes POST    Adds note to entity
    /// /contacts/:contact_id/notes/:id DELETE  Destroys note from entity
    /// </summary>
    public class Contacts : DataSource<Contact>
    {
        public Contacts(MoneyBirdClient client)
            : base(client)
        {
        }

        /// /contacts GET List all contacts
        public override async Task<IEnumerable<Contact>> GetAll()
        {
            var result = await client.GetAsync<Contact[]>("contacts.json");

            return result.Body;
        }
    }
}