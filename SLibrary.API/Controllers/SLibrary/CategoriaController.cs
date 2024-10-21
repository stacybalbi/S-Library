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
    public class CategoriaController : BaseController<Categoria, CategoriaDto>
    {
        ICategoriaService _service;
        MainDbContext _context;

        public CategoriaController(ICategoriaService service, IMapper mapper)
            : base(service, mapper)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            var list = await _service.GetAllAsync();
            var model = _mapper.Map<List<CategoriaDto>>(list);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public override async Task<IActionResult> GetById(int id)
        {
            var reqResult = await _service.GeTModelByIdAsync(id);
            if (reqResult != null)
            {
                var model = _mapper.Map<CategoriaDto>(reqResult);
                return Ok(model);
            }

            return NoContent();
        }
    }
}

