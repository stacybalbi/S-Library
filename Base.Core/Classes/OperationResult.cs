using System;
using System.Net;

namespace Base.Core.Base
{
    public class OperationResult<T> : OperationResult
    {
        public T Result { get; set; }
        public OperationResult()
        {

        }
        public OperationResult(HttpStatusCode statusCode)
        : base(statusCode)
        {
        }

        public OperationResult(bool success, HttpStatusCode statusCode)
            : base(success, statusCode)
        {
        }
    }

    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public OperationResult()
        {
            Success = false;
            Message = String.Empty;
            StatusCode = 0;
        }

        public OperationResult(HttpStatusCode statusCode)
        {
            Success = false;
            StatusCode = statusCode;
            Message = String.Empty;
        }

        public OperationResult(bool success, HttpStatusCode statusCode)
        {
            Success = success;
            StatusCode = statusCode;
            Message = String.Empty;
        }
    }
}
