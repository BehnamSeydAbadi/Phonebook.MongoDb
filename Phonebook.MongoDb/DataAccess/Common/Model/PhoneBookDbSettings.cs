namespace DataAccess.Common.Model
{
    internal record PhoneBookDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ContactsCollectionName { get; set; }
    }
}
