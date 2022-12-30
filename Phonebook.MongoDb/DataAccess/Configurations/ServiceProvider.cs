using DataAccess.Common.Model;
using DataAccess.Contact;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Configurations
{
    public static class ServiceProvider
    {
        public static void ResolveDataAccess(this IServiceCollection serviceCollection, IConfigurationSection configurationSection)
        {
            serviceCollection.Configure<PhoneBookDbSettings>(configurationSection);

            serviceCollection.AddScoped<IContactDataAccess, ContactDataAccess>();
        }
    }
}
