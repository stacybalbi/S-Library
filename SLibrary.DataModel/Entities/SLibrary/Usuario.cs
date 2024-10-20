using System;
using SLibrary.Core.Base;
using SLibrary.DataModel.Enums;

namespace SLibrary.DataModel.Entities.SLibrary
{
    public class Usuario : EntityBase
    {
        public string Email { get; set; }
        public Rol rol { get; set; }
    }
}

