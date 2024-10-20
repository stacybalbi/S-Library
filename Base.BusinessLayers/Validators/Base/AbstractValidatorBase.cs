using System;
using FluentValidation;

namespace Base.BusinessLayers.Validators.Base
{
    public class AbstractValidatorBase<TModel> : AbstractValidator<TModel> where TModel : class
    {
        public AbstractValidatorBase()
        {
            //validaciones             
        }
    }
}

