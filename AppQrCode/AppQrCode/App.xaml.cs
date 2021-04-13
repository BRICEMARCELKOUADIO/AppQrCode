using AppQrCode.Models;
using AppQrCode.ViewModels;
using AppQrCode.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace AppQrCode
{
    [Preserve(AllMembers = true)]
    public partial class App
    {
        [Preserve(AllMembers = true)]
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        [Preserve(AllMembers = true)]
        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/ScanQrCodeView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ScanQrCodeView, ScanQrCodeViewModel>();
            containerRegistry.RegisterForNavigation<QrCodeResultView, QrCodeResultViewModel>("QrCodeResult");

        }
    }
}
