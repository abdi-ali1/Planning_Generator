using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class Result<T>
    {
        private readonly T? result;
        private readonly Exception? exception;

        private Result(T? result, Exception? exception)
        {
            this.result = result;
            this.exception = exception;
        }


        public T? Value => result;
        public Exception? Exception => exception;
        public bool Success => exception is null;
        
        public bool IsExceptionType<E>() where E : Exception
        {
            return exception is not null && exception is E;
        }

        public static Result<T> Ok(T result) { return new Result<T>(result, null); }
        public static Result<T> Fail(Exception exception) { return new Result<T>(default(T), exception); }
    }
}
