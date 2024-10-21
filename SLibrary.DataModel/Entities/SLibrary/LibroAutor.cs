using System;
namespace SLibrary.DataModel.Entities.SLibrary
{
	public class LibroAutor : EntityBase
	{
		public int? LibroId { get; set; }
        public int? AutorId { get; set; }

		public Libro Libro { get; set; }
		public Autor Autor { get; set; }
    }
}

