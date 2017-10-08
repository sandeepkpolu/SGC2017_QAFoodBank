using System;

using Xamarin.Forms;

namespace QAFoodBank
{
    public partial class ItemDetailPage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            Device.OpenUri(new Uri((string)btn.CommandParameter));
        }

        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                ItemName = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

    }
}
