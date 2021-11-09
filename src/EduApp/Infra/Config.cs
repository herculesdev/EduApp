using Domain.Handlers.CommandHandlers;
using Domain.Interfaces.Handlers.CommandHandlers;
using Domain.Interfaces.Handlers.QueryHandlers;
using Domain.Interfaces.Repositories;
using Domain.Handlers.QueryHandlers;
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
            services.AddDbContext<DataContext>(opt => opt.UseSqlite(connectionString));

            // Repositories
            services.AddTransient<IStudentRepository, StudentRepository>();

            // Handlers
            services.AddTransient<IStudentCommandHandler, StudentCommandHandler>();
            services.AddTransient<IStudentQueryHandler, StudentQueryHandler>();
        }
    }
}
