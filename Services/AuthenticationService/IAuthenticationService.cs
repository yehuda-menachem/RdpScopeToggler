namespace RdpScopeToggler.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
        bool AuthenticateUser(string username, string password);
        bool RegisterUser(string username, string password);
        void LogoutUser();
        bool IsUserLoggedIn();
        string GetCurrentUsername();
    }
}
