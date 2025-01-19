using InfrastructureLayer.TaskManager.Enums;


namespace InfrastructureLayer.TaskManager.Exceptions
{
    public class InfrastructureException : Exception
    {
        public InfrastructureErrorCode ErrorCode { get; }
        public InfrastructureException(string message, InfrastructureErrorCode errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
