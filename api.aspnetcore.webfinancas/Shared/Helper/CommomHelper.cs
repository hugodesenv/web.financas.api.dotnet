namespace api.aspnetcore.webfinancas.Shared.Helper
{
    public static class CommomHelper
    {
        public static object APIResponse(int pStatusCode, string pMessage, Dictionary<string, object>? pData)
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
