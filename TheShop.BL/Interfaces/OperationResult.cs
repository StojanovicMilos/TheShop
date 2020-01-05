using System;

namespace TheShop.BL.Interfaces
{
    public class OperationResult<T>
    {
        private const string NoErrors = "";

        public bool Successful => Message == NoErrors;
        public string Message { get; }
        public T ReturnValue { get; }

        public static OperationResult<T> Failure(string message) => new OperationResult<T>(message, default(T));
        public static OperationResult<T> SuccessWithValue(T returnValue) => new OperationResult<T>(NoErrors, returnValue);
        public static OperationResult<T> Success() => SuccessWithValue(default(T));

        private OperationResult(string message, T returnValue)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            ReturnValue = returnValue;
        }
    }
}