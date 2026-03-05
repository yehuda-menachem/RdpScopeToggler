using RdpScopeToggler.Enums;

namespace RdpScopeToggler.Models
{
    public class Settings
    {
        public string Language { get; set; }
        public ActionsEnum DefaultState { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
