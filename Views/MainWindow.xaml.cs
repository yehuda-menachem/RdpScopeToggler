using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;
using Prism.Ioc;
using Prism.Navigation.Regions;
using RdpScopeToggler.Services.AuthenticationService;

namespace RdpScopeToggler.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        [StructLayout(LayoutKind.Sequential)]
        private struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        private IRegionManager _regionManager;

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;

            // Get RegionManager from Prism container
            _regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var windowHelper = new WindowInteropHelper(this);

            var margins = new MARGINS
            {
                cxLeftWidth = 1,
                cxRightWidth = 1,
                cyTopHeight = 1,
                cyBottomHeight = 1
            };

            DwmExtendFrameIntoClientArea(windowHelper.Handle, ref margins);

            SizeToContent = SizeToContent.WidthAndHeight;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                SizeToContent = SizeToContent.Manual;

                // Ensure window is on-screen
                if (this.Top < 0)
                    this.Top = 0;
                if (this.Left < 0)
                    this.Left = 0;
            }), DispatcherPriority.Loaded);

            // Update username display and enable sidebar
            var authService = ContainerLocator.Container.Resolve<IAuthenticationService>();
            string currentUser = authService.GetCurrentUsername();
            if (!string.IsNullOrWhiteSpace(currentUser))
            {
                CurrentUsername.Text = currentUser;
                SidebarBorder.IsEnabled = true;
                SidebarBorder.Visibility = Visibility.Visible;
                HeaderBorder.Visibility = Visibility.Visible;
            }
            else
            {
                // Disable sidebar if not logged in
                SidebarBorder.IsEnabled = false;
                SidebarBorder.Visibility = Visibility.Collapsed;
                HeaderBorder.Visibility = Visibility.Collapsed;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void SetActiveNav(Button activeButton)
        {
            Button[] navButtons = { NavHome, NavAccessControl, NavWhitelist, NavLocalAddresses, NavSettings };
            var inactiveStyle = (Style)FindResource("NavItemButton");
            var activeStyle = (Style)FindResource("NavItemButtonActive");

            foreach (var btn in navButtons)
            {
                btn.Style = inactiveStyle;
            }
            activeButton.Style = activeStyle;
        }

        // Navigation handlers
        private void OnHomeClick(object sender, RoutedEventArgs e)
        {
            _regionManager?.RequestNavigate("ContentRegion", "HomeUserControl");
            System.Diagnostics.Debug.WriteLine("Home Navigation called");
            SetActiveNav(NavHome);
            PageTitle.Text = "Home";
        }

        private void OnAccessControlClick(object sender, RoutedEventArgs e)
        {
            _regionManager?.RequestNavigate("ContentRegion", "AccessControlUserControl");
            System.Diagnostics.Debug.WriteLine("AccessControl Navigation called");
            SetActiveNav(NavAccessControl);
            PageTitle.Text = "Access Control";
        }

        private void OnWhitelistClick(object sender, RoutedEventArgs e)
        {
            _regionManager?.RequestNavigate("ContentRegion", "WhiteListUserControl");
            System.Diagnostics.Debug.WriteLine("Whitelist Navigation called");
            SetActiveNav(NavWhitelist);
            PageTitle.Text = "Whitelist";
        }

        private void OnLocalAddressesClick(object sender, RoutedEventArgs e)
        {
            _regionManager?.RequestNavigate("ContentRegion", "LocalAddressesUserControl");
            System.Diagnostics.Debug.WriteLine("LocalAddresses Navigation called");
            SetActiveNav(NavLocalAddresses);
            PageTitle.Text = "Local Addresses";
        }

        private void OnSettingsClick(object sender, RoutedEventArgs e)
        {
            _regionManager?.RequestNavigate("ContentRegion", "SettingsUserControl");
            System.Diagnostics.Debug.WriteLine("Settings Navigation called");
            SetActiveNav(NavSettings);
            PageTitle.Text = "Settings";
        }

        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var authService = ContainerLocator.Container.Resolve<IAuthenticationService>();
                authService.LogoutUser();

                // Disable and hide sidebar/header
                SidebarBorder.IsEnabled = false;
                SidebarBorder.Visibility = Visibility.Collapsed;
                HeaderBorder.Visibility = Visibility.Collapsed;

                // Navigate back to login
                _regionManager?.RequestNavigate("ContentRegion", "LoginUserControl");
            }
        }
    }
}
