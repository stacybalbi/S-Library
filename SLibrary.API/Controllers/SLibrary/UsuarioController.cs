using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SLibrary.BusinessLayers.Dtos.SLibrary;
using SLibrary.BusinessLayers.Interfaces.SLibrary;
using SLibrary.Controllers.Base;
using SLibrary.DataModel.Context;
using SLibrary.DataModel.Entities.SLibrary;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SLibrary.API.Controllers.SLibrary
{
    [Authorize(Policy = "RequireAdministratorRole")]
    public class UsuarioController : BaseController<Usuario, UsuarioDto>
    {
        IUsuarioService _service;
        MainDbContext _context;

        public UsuarioController(IUsuarioService service, IMapper mapper)
            : base(service, mapper)
        {
            _service = service;
        }

        
    }
}

