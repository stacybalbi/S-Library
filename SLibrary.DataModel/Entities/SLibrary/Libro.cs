using System;
using SLibrary.Core.Base;

namespace SLibrary.DataModel.Entities.SLibrary
{
    public class Libro : EntityBase
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<Autor> Autores { get; set; }
        public ICollection<Categoria> Categorias { get; set; }

    }
}

