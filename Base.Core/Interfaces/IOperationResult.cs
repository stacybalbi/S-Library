using System;
namespace Base.Core.Interfaces
{
    public interface IOperationResult<T>
    {
        public bool Success { get; set; }

        public T Entity { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorDetail { get; set; }
    }
}

