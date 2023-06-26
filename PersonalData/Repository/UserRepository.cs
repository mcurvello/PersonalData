using System.Data;
using System.Security.Cryptography;
using System.Text;
using PersonalData.Data.VO;
using PersonalData.Model;
using PersonalData.Model.Context;

namespace PersonalData.Repository
{
	public class UserRepository : IUserRepository
	{
        public readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, SHA256.Create());

            return _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == pass);
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;
            
            var result = _context.Users.SingleOrDefault(u => u.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private string ComputeHash(string password, SHA256 algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}

