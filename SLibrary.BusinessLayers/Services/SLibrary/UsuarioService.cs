using System;
using AutoMapper;
using FluentValidation;
using SLibrary.BusinessLayers.Interfaces.SLibrary;
using SLibrary.BusinessLayers.Services.Base;
using SLibrary.DataModel.Context;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.BusinessLayers.Services.SLibrary
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        public UsuarioService(MainDbContext context, IValidator<Usuario> validator, IMapper mapper)
            : base(context, validator, mapper)
        {
        }
    }
}

