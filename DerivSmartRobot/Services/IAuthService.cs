using DerivSmartRobot.Models.View;

namespace DerivSmartRobot.Services
{

    public interface IAuthService
    {
        Task<User> Login(string email, string password);
        Task<string> UpdatePassword(string email, string password);
        Task<string> SaveConfig(string email, string accountType, string apiToken);

        Task<User> GetOAuthData(string email, string userJwtToken);

    }
}