using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SLibrary.DataModel.Context;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLibrary.BusinessLayers.Interfaces.SLibrary;
using SLibrary.BusinessLayers.Services.SLibrary;
using FluentValidation;
using SLibrary.BusinessLayers.Validators.SLibrary;
using SLibrary.DataModel.Entities.SLibrary;
using SLibrary.BusinessLayers.Mappers.SLibrary;

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
            services.AddTransient<ILibroAutorService, LibroAutorService>();
            services.AddTransient<ILibroCategoriaService, LibroCategoriaService>();

            services.AddTransient<IValidator<Autor>, AutorValidator>();
            services.AddTransient<IValidator<Categoria>, CategoriaValidator>();
            services.AddTransient<IValidator<Libro>, LibroValidator>();
            services.AddTransient<IValidator<Usuario>, UsuarioValidator>();
            services.AddTransient<IValidator<LibroAutor>, LibroAutorValidator>();
            services.AddTransient<IValidator<LibroCategoria>, LibroCategoriaValidator>();

            services.AddAutoMapper(typeof(SLibraryMapper));

            return services;

        }
       

    }
}

