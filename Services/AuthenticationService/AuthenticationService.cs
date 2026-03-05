using RdpScopeToggler.Services.FilesService;
using System;
using System.Security.Cryptography;
using System.Text;

namespace RdpScopeToggler.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IFilesService _filesService;

        public AuthenticationService(IFilesService filesService)
        {
            _filesService = filesService;
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public bool VerifyPassword(string password, string hash)
        {
            try
            {
                var hashOfInput = HashPassword(password);
                return hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            var savedUsername = _filesService.GetSavedUsername();
            var savedPasswordHash = _filesService.GetSavedPasswordHash();

            if (string.IsNullOrWhiteSpace(savedUsername) || string.IsNullOrWhiteSpace(savedPasswordHash))
            {
                return false;
            }

            if (!username.Equals(savedUsername, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!VerifyPassword(password, savedPasswordHash))
            {
                return false;
            }

            return true;
        }

        public bool RegisterUser(string username, string password)
        {
            // Check if user already registered
            var savedUsername = _filesService.GetSavedUsername();
            if (!string.IsNullOrWhiteSpace(savedUsername))
            {
                // User already exists
                return false;
            }

            // Validate input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (username.Length < 3 || password.Length < 6)
            {
                return false;
            }

            // Save credentials
            var passwordHash = HashPassword(password);
            _filesService.SaveCredentials(username, passwordHash);

            return true;
        }

        public void LogoutUser()
        {
            _filesService.ClearCredentials();
        }

        public bool IsUserLoggedIn()
        {
            return _filesService.IsUserLoggedIn();
        }

        public string GetCurrentUsername()
        {
            return _filesService.GetSavedUsername();
        }
    }
}
