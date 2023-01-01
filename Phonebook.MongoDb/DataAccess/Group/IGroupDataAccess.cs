namespace DataAccess.Group
{
    public interface IGroupDataAccess
    {
        Task InsertAsync(GroupEntity entity);
    }
}
