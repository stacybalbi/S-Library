using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SLibrary.DataModel.Context;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SLibrary.BusinessLayers
{
	public static class IoC
	{

        public static IServiceCollection AddBusinnesLayers(this IServiceCollection services)
        {


            return services;


        }
       

    }
}

