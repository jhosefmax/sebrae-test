using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Sebrae.Persistence
{
    public static class Dependencies
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Database

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseInMemoryDatabase("ContaDatabase");
            });

            #endregion Database
        }
    }
}
