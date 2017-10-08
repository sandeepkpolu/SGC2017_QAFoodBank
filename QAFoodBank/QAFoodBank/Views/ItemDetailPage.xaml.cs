using System;

using Xamarin.Forms;

namespace QAFoodBank
{
    public partial class ItemDetailPage : ContentPage
    {
        public void Handle_Tapped(object sender, System.EventArgs e)
        {
            TappedEventArgs args = (TappedEventArgs)e;
            Device.OpenUri(new Uri((string)args.Parameter));
        }

        public void Provider_Clicked(object sender, System.EventArgs e)
        {

            Button btn = (Button)sender;
            Device.OpenUri(new Uri((string)btn.CommandParameter));

        }

        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

    }
}
