namespace WebAPI.Contact.ViewModels
{
    public sealed record ContactViewModel
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
    }
}
