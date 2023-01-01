using DataAccess.Common.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccess.Group
{
    internal class GroupDataAccess : IGroupDataAccess
    {
        private readonly IMongoCollection<GroupEntity> _groupsCollection;

        public GroupDataAccess(IOptions<PhoneBookDbSettings> phoneBookDbSettings)
        {
            var mongoClient = new MongoClient(phoneBookDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(phoneBookDbSettings.Value.DatabaseName);
            _groupsCollection = mongoDatabase.GetCollection<GroupEntity>(phoneBookDbSettings.Value.GroupsCollectionName);
        }

        public async Task InsertAsync(GroupEntity entity)
            => await _groupsCollection.InsertOneAsync(entity);
    }
}
