using Domain.CommandHandlers;
using Domain.Interfaces.CommandHandlers;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public class Config
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // DataContexts
            services.AddDbContextPool<DataContext>(opt => opt.UseMySQL(connectionString));

            // Repositories
            services.AddTransient<IStudentRepository, StudentRepository>();

            // Handlers
            services.AddTransient<IStudentCommandHandler, StudentCommandHandler>();
        }
    }
}
