using System;
using AutoMapper;
using FluentValidation;
using SLibrary.BusinessLayers.Interfaces.SLibrary;
using SLibrary.BusinessLayers.Services.Base;
using SLibrary.DataModel.Context;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.BusinessLayers.Services.SLibrary
{
    public class LibroCategoriaService : BaseService<LibroCategoria>, ICategoriaService
    {
        public LibroCategoriaService(MainDbContext context, IValidator<LibroCategoria> validator, IMapper mapper)
            : base(context, validator, mapper)
        {
        }
    }
}

