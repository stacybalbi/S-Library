using System;
using SLibrary.Core.Base;

namespace SLibrary.DataModel.Entities.SLibrary
{
	public class Autor : EntityBase
	{
		public string Nombre { get; set; }

        public ICollection<Libro> Libros { get; set; }
    }
}

