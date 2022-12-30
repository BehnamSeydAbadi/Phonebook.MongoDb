using DataAccess.Common.Model;
using DataAccess.Contact.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Contact
{
    internal class ContactDataAccess : IContactDataAccess
    {
        private readonly IMongoCollection<ContactEntity> _contactsCollection;

        public ContactDataAccess(IOptions<PhoneBookDbSettings> phoneBookDbSettings)
        {
            var mongoClient = new MongoClient(phoneBookDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(phoneBookDbSettings.Value.DatabaseName);
            _contactsCollection = mongoDatabase.GetCollection<ContactEntity>(phoneBookDbSettings.Value.ContactsCollectionName);
        }

        public async Task InsertAsync(ContactEntity entity)
            => await _contactsCollection.InsertOneAsync(entity);
    }
}
