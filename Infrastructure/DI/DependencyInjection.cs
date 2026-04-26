using System.Data;
using Application.InterfaceRepository;
using Application.IService;
using Application.Query;
using Domain.Entity;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString)); //EF

            services.AddScoped<IDbConnection>(sp =>
                 new NpgsqlConnection(connectionString));//DAPPER

            services.AddScoped<IRepository<Vacancy>, VacancyRepository>();
            services.AddScoped<IParsingService, ParsingService>();

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(GetVacanciesQuery).Assembly);
            });

            return services;
        }
    }
}
