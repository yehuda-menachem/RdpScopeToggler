using Prism.Navigation;
using Prism.Navigation.Regions;
using RdpScopeToggler.Models;
using RdpScopeToggler.Services.PipeClientService;
using System.Windows;

namespace RdpScopeToggler.Managers
{
    public class NavigationManager
    {
        private readonly IRegionManager regionManager;
        public NavigationManager(IPipeClientService pipeClientService, IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            pipeClientService.MessageReceived += UpdateNavigate;
        }

        private void UpdateNavigate(ServiceMessage message)
        {
            // Don't navigate on every message - let user control navigation
            // The navigation should only happen on explicit user action via MainWindow buttons
            // This prevents service messages from interrupting user navigation

            // If needed in the future, we can check if we're already on a specific page
            // before navigating, or only navigate on specific message types
        }
    }
}
