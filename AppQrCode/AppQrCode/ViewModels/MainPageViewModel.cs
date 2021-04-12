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
    public class MainPageViewModel : ViewModelBase
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

        public MainPageViewModel(INavigationService navigationService)
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
                            { "QrCodeData", Result.Text },
                        };
                        await NavigationService.NavigateAsync("QrCodeResult", parameters).ConfigureAwait(false);
                    }
                }
                catch (Exception)
                {
                }
            });
        }

        public async Task OpenBrowser(Uri uri)
        {
            try
            {
                await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }

        public void OnPushFlashButton()
        {
            IsTorchOn = !IsTorchOn;
        }
    }
}
