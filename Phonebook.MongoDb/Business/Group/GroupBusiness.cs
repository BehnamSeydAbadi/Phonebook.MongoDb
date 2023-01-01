using DataAccess.Group;

namespace Business.Group
{
    internal class GroupBusiness : IGroupBusiness
    {
        private readonly IGroupDataAccess _groupDataAccess;

        public GroupBusiness(IGroupDataAccess groupDataAccess)
        {
            _groupDataAccess = groupDataAccess;
        }

        public async Task<string> InsertAsync(string title)
        {
            var entity = new GroupEntity { Title = title };

            await _groupDataAccess.InsertAsync(entity);

            return entity.Id;
        }
    }
}
