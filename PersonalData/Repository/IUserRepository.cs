using PersonalData.Data.VO;
using PersonalData.Model;

namespace PersonalData.Repository
{
	public interface IUserRepository
	{
		User ValidateCredentials(UserVO user);

		User RefreshUserInfo(User user);
    }
}
