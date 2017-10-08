using System;
using Xamarin.Forms;

namespace QAFoodBank
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public Item Item { get; set; }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Name;
            Item = item;
        }

    }
}
