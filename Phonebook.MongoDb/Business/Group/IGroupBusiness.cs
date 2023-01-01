namespace Business.Group
{
    public interface IGroupBusiness
    {
        Task<string> InsertAsync(string title);
    }
}
