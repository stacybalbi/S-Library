using System;
namespace SLibrary.DataModel.Entities.SLibrary
{
	public class LibroCategoria : EntityBase
	{
        public int? LibroId { get; set; }
        public int? CategoriaId { get; set; }

        public Libro Libro { get; set; }
        public Categoria Autor { get; set; }
    }
}

