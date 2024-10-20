using System;
using AutoMapper;
using FluentValidation;
using SLibrary.BusinessLayers.Interfaces.SLibrary;
using SLibrary.BusinessLayers.Services.Base;
using SLibrary.DataModel.Context;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.BusinessLayers.Services.SLibrary
{
    public class CategoriaService : BaseService<Categoria>, ICategoriaService
    {
        public CategoriaService(MainDbContext context, IValidator<Categoria> validator, IMapper mapper)
            : base(context, validator, mapper)
        {
        }
    }
}

