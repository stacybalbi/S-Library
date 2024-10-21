using System;
using SLibrary.Core.Base;

namespace SLibrary.BusinessLayers.Dtos.SLibrary
{
	public class AuthDto : DtoBase
	{
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

