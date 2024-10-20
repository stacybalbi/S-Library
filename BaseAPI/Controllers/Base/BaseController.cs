using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Base.Core.Base;
using Base.BusinessLayers.Services.Base;
using AutoMapper;

namespace BaseAPI.Controllers.Base
{
    [Route("Api/[controller]")]
    public abstract class BaseController<TEntity, TDto> : ControllerBase
    where TEntity : class, IEntityBase, new()
    where TDto : class, IDtoBase, new()
    {

        protected readonly IBaseService<TEntity> _db;
        protected readonly IMapper _mapper;

        protected BaseController(IBaseService<TEntity> db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {

            var list = await _db.GetAllAsync();

            var model = _mapper.Map<List<TDto>>(list);

            return Ok(model);
        }


        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var reqResult = await _db.GeTModelByIdAsync(id);
            if (reqResult != null)
            {
                var model = _mapper.Map<TDto>(reqResult);
                return Ok(model);
            }

            return NoContent();
        }

        // POST api/values/
        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto dto)
        {
            if (dto == null)
            {
                return BadRequest(new OperationResult() { StatusCode = HttpStatusCode.BadRequest });
            }
            var model = _mapper.Map<TEntity>(dto);

            var resultRepository = await _db.Add(model);
            if (!resultRepository.Success)
                return BadRequest(resultRepository);

            var resultSave = await _db.SaveAsync();
            if (!resultSave.Success)
                return BadRequest(resultSave);

            var result = new OperationResult<TDto>()
            {
                Result = _mapper.Map<TDto>(model),
                Success = true,
                StatusCode = HttpStatusCode.Created
            };
            return Ok(result);
        }

        [HttpPut("{key}")]
        public virtual async Task<IActionResult> Put(int key, [FromBody] TDto dto)
        {
            if (dto == null || key < 1)
            {
                return BadRequest(new OperationResult() { StatusCode = HttpStatusCode.BadRequest });
            }

            var find = await _db.Find(key);
            if (find == null)
            {
                return NotFound(new OperationResult() { StatusCode = HttpStatusCode.NotFound });
            }
            var model = _mapper.Map<TEntity>(dto);
            var result = _db.Update(model);
            if (result.Success)
            {
                var resultSave = await _db.SaveAsync();
                if (!resultSave.Success)
                    return BadRequest(resultSave);

                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{key}")]
        public virtual async Task<IActionResult> Delete(int key)
        {
            if (key < 1)
            {
                return BadRequest(new OperationResult() { StatusCode = HttpStatusCode.BadRequest });
            }

            var model = await _db.Find(key);
            if (model == null)
            {
                return NotFound(new OperationResult() { StatusCode = HttpStatusCode.NotFound });
            }
            //
            var result = _db.Remove(model);
            if (result.Success)
            {
                var resultSave = await _db.SaveAsync();
                if (!resultSave.Success)
                    return BadRequest(resultSave);

                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}

