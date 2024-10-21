using System;
using SLibrary.Core.Base;
using SLibrary.DataModel.Enums;

namespace SLibrary.BusinessLayers.Dtos.SLibrary
{
    public class UsuarioDto : DtoBase
    {
        public string Email { get; set; }

        public string Password {get; set;}
        public Rol rol { get; set; }
    }
}

