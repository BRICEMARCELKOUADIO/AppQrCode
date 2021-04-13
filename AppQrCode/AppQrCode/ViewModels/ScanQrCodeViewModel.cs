using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppQrCode.ViewModels
{
    public class ScanQrCodeViewModel : ViewModelBase
    {
        private ZXing.Result _result;
        public ZXing.Result Result
        {
            get { return _result; }
            set
            {
                SetProperty(ref _result, value);
            }
        }

        private bool _isScanning = true;
        public bool IsScanning
        {
            get { return _isScanning; }
            set
            {
                SetProperty(ref _isScanning, value);
            }
        }

        private bool _isTorchOn = false;
        public bool IsTorchOn
        {
            get { return _isTorchOn; }
            set
            {
                SetProperty(ref _isTorchOn, value);
            }
        }

        public ICommand QRScanResultCommand => new DelegateCommand(QRScanResult);

        public ScanQrCodeViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "SCAN QR CODE";
        }

        private void QRScanResult()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(Result.Text))
                    {
                        await OpenBrowser(new Uri(Result.Text));
                    }
                    else
                    {
                        var parameters = new NavigationParameters
                        {
                            { "id", "id" },
                            { "QrCodeData", "Aucun contenu dans ce QrCode" },
                        };
                        await NavigationService.NavigateAsync("QrCodeResult", parameters).ConfigureAwait(false);
                    }
                }
                catch (Exception)
                {
                    var parameters = new NavigationParameters
                        {
                            { "id", "id" },
                            { "QrCodeData", "Une erreur inconnue s'est produite, assurez-vous de scanner le bon QrCode" },
                        };
                    await NavigationService.NavigateAsync("QrCodeResult", parameters).ConfigureAwait(false);
                }
            });
        }

        public async Task OpenBrowser(Uri uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception)
            {
                var parameters = new NavigationParameters
                        {
                            { "id", "id" },
                            { "QrCodeData", "Aucun navigateur trouvé sur votre mobile" },
                        };
                await NavigationService.NavigateAsync("QrCodeResult", parameters).ConfigureAwait(false);
            }
        }

        public void OnPushFlashButton()
        {
            IsTorchOn = !IsTorchOn;
        }
    }
}
