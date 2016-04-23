using System;

namespace Helper.Model
{
    public class Result<T>
    {
        public bool State { get; set; } = false;
        public T Data { get; set; } = default(T);
        public Exception ExceptionData { get; set; } = null;
    }
}