using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Northwind.DataContext.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.EntityModels
{
    public static class NorthwindContextExtensions
    {
        public static IServiceCollection AddNorthwindContext(this IServiceCollection services, string? connectionString = null)

        {
            if (connectionString == null) 
            {
                SqlConnectionStringBuilder builder = new();
                builder.DataSource = "(localdb)\\MSSQLLocalDB";
                builder.InitialCatalog = "NorthwindDatabase";
                builder.TrustServerCertificate = true;
                builder.MultipleActiveResultSets = true;
                builder.ConnectTimeout = 3;
                builder.IntegratedSecurity = true;
                //builder.UserID = Environment.GetEnvironmentVariable("MY_SQL_USR");
                // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");
                connectionString = builder.ConnectionString;
            }
            services.AddDbContext<NorthwindDatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.LogTo(NorthwindContextLogger.WriteLine,
                new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
            },
             contextLifetime: ServiceLifetime.Transient,
             optionsLifetime: ServiceLifetime.Transient);

            return services;
        }
        
    }
}
