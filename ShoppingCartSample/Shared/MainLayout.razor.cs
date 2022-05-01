using AKSoftware.Blazor.Utilities;
using ShoppingCartSample.Components;
using ShoppingCartSample.Models;

namespace ShoppingCartSample.Shared
{
    public partial class MainLayout
    {

		private decimal _totalAmount = 0;

		protected override void OnInitialized()
		{
			// Subscribe to the cartitem_removed message to reduce the total amount of the cart
			MessagingCenter.Subscribe<ShoppingCart, CartItem>(this, "cartitem_removed", (sender, item) =>
			{
				_totalAmount -= item.TotalPrice;
				StateHasChanged(); 
			});

			// Subscribe to the item_added message to increase the total amount of the cart
			MessagingCenter.Subscribe<ProductsList, Item>(this, "item_added", (sender, item) =>
			{
				_totalAmount += item.Price;
				StateHasChanged();
			});
		}

	}
}