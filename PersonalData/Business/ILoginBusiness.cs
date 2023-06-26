using PersonalData.Data.VO;

namespace PersonalData.Business
{
	public interface ILoginBusiness
	{
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);
    }
}
