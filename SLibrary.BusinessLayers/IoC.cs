using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SLibrary.DataModel.Context;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLibrary.BusinessLayers.Interfaces.SLibrary;
using SLibrary.BusinessLayers.Services.SLibrary;

namespace SLibrary.BusinessLayers
{
	public static class IoC
	{

        public static IServiceCollection AddBusinnesLayers(this IServiceCollection services)
        {
            services.AddTransient<IAutorService, AutorService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<ILibroService, LibroService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            return services;


        }
       

    }
}

