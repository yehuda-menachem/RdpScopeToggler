using System.Windows;
using System.Windows.Controls;
using Prism.Navigation.Regions;
using RdpScopeToggler.Services.AuthenticationService;
using Prism.Ioc;

namespace RdpScopeToggler.Views
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        private IAuthenticationService _authService;
        private IRegionManager _regionManager;

        public LoginUserControl()
        {
            InitializeComponent();
            Loaded += LoginUserControl_Loaded;
        }

        private void LoginUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _authService = ContainerLocator.Container.Resolve<IAuthenticationService>();
            _regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_authService.AuthenticateUser(username, password))
            {
                // Login successful
                MessageBox.Show($"Welcome back, {username}!", "Login Successful",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                _regionManager?.RequestNavigate("ContentRegion", "HomeUserControl");
            }
            else
            {
                // Check if user exists
                if (string.IsNullOrWhiteSpace(_authService.GetCurrentUsername()))
                {
                    // No user registered yet
                    var result = MessageBox.Show("No account found. Would you like to create one?", "Account Not Found",
                        MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        _regionManager?.RequestNavigate("ContentRegion", "RegisterUserControl");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void WindowsAuthButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string windowsUsername = System.Environment.UserName;

                // For Windows Authentication, we use the Windows username as-is
                // In a real scenario, you might validate against AD or another service
                if (!string.IsNullOrWhiteSpace(windowsUsername))
                {
                    // Try to authenticate with Windows credentials
                    if (_authService.AuthenticateUser(windowsUsername, "windows-auth"))
                    {
                        MessageBox.Show($"Welcome, {windowsUsername}!", "Authentication Successful",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        _regionManager?.RequestNavigate("ContentRegion", "HomeUserControl");
                    }
                    else
                    {
                        // If no account exists, offer to register with Windows username
                        var result = MessageBox.Show(
                            $"No account found for '{windowsUsername}'. Create one?",
                            "Account Not Found",
                            MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            // Register with Windows username
                            if (_authService.RegisterUser(windowsUsername, "windows-auth"))
                            {
                                MessageBox.Show($"Account created for {windowsUsername}!",
                                    "Registration Successful",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                                _regionManager?.RequestNavigate("ContentRegion", "HomeUserControl");
                            }
                            else
                            {
                                MessageBox.Show("Failed to create account.", "Registration Failed",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Windows Authentication Error: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
