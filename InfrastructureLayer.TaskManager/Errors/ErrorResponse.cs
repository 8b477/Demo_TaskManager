
namespace InfrastructureLayer.TaskManager.Errors
{
    internal static class ErrorResponse
    {
        internal static string NotFound()
        {
            return "the requested resource is not available";
        }

        internal static string BadRequest()
        {
            return "The request is not correct";
        }

        internal static string Unauthorized()
        {
            return "The request is not authorized";
        }

    }
}
