using System;
using Microsoft.AspNetCore.Mvc;

namespace SLibrary.Controllers.Base
{
	public interface IBaseController<TEntity> where TEntity : class
    {

        Task<IActionResult> Get();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(TEntity entity);
        Task<IActionResult> Edit(TEntity entity);
        Task<IActionResult> Delete(int id);

    }
}

