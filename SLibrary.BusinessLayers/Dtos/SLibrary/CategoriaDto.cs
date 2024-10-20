using System;
using SLibrary.Core.Base;

namespace SLibrary.BusinessLayers.Dtos.SLibrary
{
    public class CategoriaDto : DtoBase
    {
        public string Nombre { get; set; }

        public ICollection<LibroDto> Libros { get; set; }
    }
}

