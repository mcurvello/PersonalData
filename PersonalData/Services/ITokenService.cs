using System.Security.Claims;

namespace PersonalData.Services
{
	public interface ITokenService
	{
		string GenerateAccessToken(IEnumerable<Claim> claims);
		string GenerateRefreshToken();
		ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
	}
}
