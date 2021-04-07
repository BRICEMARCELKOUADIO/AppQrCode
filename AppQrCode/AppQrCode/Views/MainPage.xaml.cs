
using AppQrCode.ViewModels;
using System;
using Xamarin.Forms;

namespace AppQrCode.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnFlashButtonClicked(Button sender, EventArgs e)
        {
            ((MainPageViewModel)BindingContext).OnPushFlashButton();
        }
    }
}
