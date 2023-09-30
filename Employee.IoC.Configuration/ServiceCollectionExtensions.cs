using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Employee.Service.Model;
using Employee.Model;
using Employee.Repository.Interface;
using Employee.Repository.Concrete;
using FluentValidation;
using Employee.Core;
using MediatR;
using Employee.Core.Behavior;

namespace Employee.IoC.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection  MapCore (this IServiceCollection services, IConfiguration configuration )
    {
        services.AddDbContext<EmployeeDbContext>(option => option.UseSqlServer
        (configuration.GetConnectionString("defaultconnection")));

        services.AddAutoMapper(typeof(MappingExtension).Assembly);
        services.AddTransient<IEmployeeRepository,EmployeeRepository>();
        services.AddTransient<ICountryRepository,CountryRepository>();
        services.AddTransient<IStateRepository,StateRepository>();

        services.AddValidatorsFromAssembly(typeof(ICore).Assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        return services;
    }
}
