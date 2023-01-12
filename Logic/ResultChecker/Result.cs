namespace Logic
{
    public class Result<T>
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

        /// <summary>
        /// Determines whether the exception stored in this Result object is of the specified exception type.
        /// </summary>
        /// <typeparam name="E">The type of exception to check for.</typeparam>
        /// <returns>True if the exception stored in this Result object is of the specified type, otherwise false.</returns>
        public bool IsExceptionType<E>() where E : Exception
        {
            return exception is not null && exception is E;
        }

        /// <summary>
        /// Creates a new Result object with a success status.
        /// </summary>
        /// <param name="result">The result of the operation.</param>
        /// <returns>A Result object with a success status and the specified result.</returns>
        public static Result<T> Ok(T result)
        {
            return new Result<T>(result, null);
        }

        /// <summary>
        /// Creates a new Result object with a failure status.
        /// </summary>
        /// <param name="exception">The exception that occurred during the operation.</param>
        /// <returns>A Result object with a failure status and the specified exception.</returns>
        public static Result<T> Fail(Exception exception)
        {
            return new Result<T>(default(T), exception);
        }
    }
}
