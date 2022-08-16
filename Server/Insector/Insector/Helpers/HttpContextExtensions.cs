using System.Security.Claims;

namespace Insector.Helpers
{
    public static class HttpContextExtensions
    {
        public static int GetUserId(this HttpContext context)
        {
            var id = context.User.FindFirst(ClaimTypes.PrimarySid)?.Value;
            return Convert.ToInt32(id);
        }
    }
}
