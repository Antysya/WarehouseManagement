using DataModel;

namespace Server.Auth
{
    public interface IJwtProvider
    {
        public string GenerateToken(Users user);
    }
}