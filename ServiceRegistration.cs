using Hospitalpage.Infrastructure.Contract;
using Hospitalpage.Infrastructure.Manager;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace Hospitalpage
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterBusinessService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IAppoinment, UserAppoinment>();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
            configuration.GetConnectionString("DBAppoinment"),
             new MySqlServerVersion(new Version(8, 0, 30)) // Update with your MySQL version
             )
             );
            return services;
        }

    }
}
