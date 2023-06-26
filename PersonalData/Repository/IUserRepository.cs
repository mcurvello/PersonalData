using PersonalData.Data.VO;
using PersonalData.Model;

namespace PersonalData.Repository
{
	public interface IUserRepository
	{
		User ValidateCredentials(UserVO user);

		User ValidateCredentials(string username);

		User RefreshUserInfo(User user);

		bool RevokeToken(string username);
    }
}
