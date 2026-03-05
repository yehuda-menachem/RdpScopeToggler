using System.Windows;
using System.Windows.Controls;
using Prism.Navigation.Regions;
using RdpScopeToggler.Services.AuthenticationService;
using Prism.Ioc;

namespace RdpScopeToggler.Views
{
    /// <summary>
    /// Interaction logic for RegisterUserControl.xaml
    /// </summary>
    public partial class RegisterUserControl : UserControl
    {
        private IAuthenticationService _authService;
        private IRegionManager _regionManager;

        public RegisterUserControl()
        {
            InitializeComponent();
            Loaded += RegisterUserControl_Loaded;
        }

        private void RegisterUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _authService = ContainerLocator.Container.Resolve<IAuthenticationService>();
            _regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            // Validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Register user
            if (_authService.RegisterUser(username, password))
            {
                MessageBox.Show($"Account created successfully for {username}!", "Registration Successful",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                // Update MainWindow UI state for authenticated user
                var mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow?.ShowAuthenticatedUI();

                _regionManager?.RequestNavigate("ContentRegion", "HomeUserControl");
            }
            else
            {
                MessageBox.Show("Failed to create account. An account may already exist.", "Registration Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            _regionManager?.RequestNavigate("ContentRegion", "LoginUserControl");
        }
    }
}
