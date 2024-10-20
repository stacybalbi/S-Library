using System;
using FluentValidation;
using SLibrary.BusinessLayers.Validators.Base;
using SLibrary.DataModel.Entities.SLibrary;

namespace SLibrary.BusinessLayers.Validators.SLibrary
{
	public class AutorValidator : AbstractValidator<Autor>
    {
        public AutorValidator() { }
    }
}

