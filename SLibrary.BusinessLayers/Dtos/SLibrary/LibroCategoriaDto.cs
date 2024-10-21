using System;
using SLibrary.Core.Base;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.BusinessLayers.Dtos.SLibrary
{
	public class LibroCategoriaDto : DtoBase
	{
        public int? LibroId { get; set; }
        public int? CategoriaId { get; set; }

        public LibroDto Libro { get; set; }
        public CategoriaDto Autor { get; set; }
    }
}

