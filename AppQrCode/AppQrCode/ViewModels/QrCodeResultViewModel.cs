using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppQrCode.ViewModels
{
    public class QrCodeResultViewModel : ViewModelBase
    {
        private string _qrCodeResult;
        public string QrCodeResult
        {
            get { return _qrCodeResult; }
            set { SetProperty(ref _qrCodeResult, value); }
        }

        public QrCodeResultViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Qr Code Error";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var Id = parameters.GetValue<string>("id");

            if (!string.IsNullOrEmpty(Id))
            {
                QrCodeResult = parameters.GetValue<string>("QrCodeData");
            }

        }
    }
}
