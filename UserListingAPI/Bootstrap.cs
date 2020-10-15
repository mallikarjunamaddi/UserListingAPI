using Microsoft.Extensions.DependencyInjection;

using UserListingAPI.Business;
using UserListingAPI.Repository;
using UserListingAPI.Business.BusinessContracts;
using UserListingAPI.Repository.RepositoryContracts;

namespace UserListingAPI
{
	public class Bootstrap
	{
        /// <summary>
        /// Register the Dependencies of Business and Repository
        /// </summary>
        /// <param name="services"></param>
        public static void Register(IServiceCollection services)
        {
            // Register dependency of Business layer.
            services.AddScoped<IUserBusiness, UserBusiness>();

            // Register dependency of Repository layer
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
