namespace api.aspnetcore.webfinancas.Application.Utils
{
    public static class HandleUtils
    {
        public static object APIResponse(Int32 pStatusCode, string pMessage, Dictionary<string, object>? pData)
        {
            return new
            {
                statusCode = pStatusCode,
                message = pMessage,
                data = pData
            };
        }
    }
}
