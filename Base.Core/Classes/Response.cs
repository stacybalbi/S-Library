using System;
namespace Base.Core.Classes
{
    public class Response
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
        public object Object { get; set; }
    }
}

