using System.Security.Claims;

namespace DotNetCore.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Claim Claim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            return claimsPrincipal?.FindFirst(claimType);
        }

        public static string ClaimNameIdentifier(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claim(ClaimTypes.NameIdentifier)?.Value;
        }

        public static long Id(this ClaimsPrincipal claimsPrincipal)
        {
            return long.TryParse(claimsPrincipal.ClaimNameIdentifier(), out var value) ? value : 0;
        }
    }
}
