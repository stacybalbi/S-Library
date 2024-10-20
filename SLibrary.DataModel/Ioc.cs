using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLibrary.DataModel.Context;

namespace SLibrary.DataModel
{
	public static class Ioc
    {
        public static IServiceCollection AddDataModel(this IServiceCollection services, IConfiguration configuration)
        {
      
            services.AddDbContext<MainDbContext>(opt =>
                opt.UseSqlite(configuration.GetConnectionString("MainDatabase"),
                b => b.MigrationsAssembly("SLibrary.Api")));

            return services;


        }


    }
}


