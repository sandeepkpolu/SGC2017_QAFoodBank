using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QAFoodBank
{
    public partial class ItemsPage : ContentPage
    {
        void Twitter_Tapped(object sender, System.EventArgs e)
        {
			try
			{
				Device.OpenUri(new Uri("twitter://qafoodbanksh"));
			}
			catch (Exception)
			{
                var message = "Thank you for donating to Quen Anne Food bank";
                var weblink = "https://qafb.org";
                var tweetlink = String.Format("http://twitter.com/share?text={0}&url={1}", message, weblink);
                Device.OpenUri(new Uri(tweetlink));
			}
        }

		void Facebook_Tapped(object sender, System.EventArgs e)
		{
			try
			{
				Device.OpenUri(new Uri("fb://queenannefoodbank/?ref=br_rs"));
			}
			catch (Exception)
			{
				Device.OpenUri(new Uri("https://www.facebook.com/sharer/sharer.php?u=https%3A%2F%2Fwww.qafb.org%2F&amp;src=sdkpreparse%22%3EShare"));

			}
		}

        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;      
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
