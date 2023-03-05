using Locator.api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Locator.api.Auth
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
