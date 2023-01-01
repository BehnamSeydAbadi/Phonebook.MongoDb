using Business.Contact;
using Business.Group;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Configurations
{
    public static class ServiceProvider
    {
        public static void ResolveBusiness(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IContactBusiness, ContactBusiness>();
            serviceCollection.AddScoped<IGroupBusiness, GroupBusiness>();
        }
    }
}
