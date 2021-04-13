
using AppQrCode.ViewModels;
using System;
using Xamarin.Forms;

namespace AppQrCode.Views
{
    public partial class ScanQrCodeView
    {
        public ScanQrCodeView()
        {
            InitializeComponent();
        }

        private void OnFlashButtonClicked(Button sender, EventArgs e)
        {
            ((ScanQrCodeViewModel)BindingContext).OnPushFlashButton();
        }
    }
}
