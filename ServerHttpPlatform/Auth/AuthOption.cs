using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KMA.Coursework.CommunicationPlatform.ServerHttpPlatform.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "ServerHttpPlatform"; 
        public const string AUDIENCE = "ServerHttpPlatform"; 
        const string KEY = "platform_utc_super_secret_KEY_345112";  
        public const int LIFETIME = 30; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}