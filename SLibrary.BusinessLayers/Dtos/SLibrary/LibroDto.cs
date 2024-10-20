using System;
using SLibrary.Core.Base;

namespace SLibrary.BusinessLayers.Dtos.SLibrary
{
    public class LibroDto : DtoBase
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

    }
}

