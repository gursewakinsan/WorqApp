using Mopups.Pages;
using WorqApp.ViewModels;

namespace WorqApp.PopupPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemOutOfStockPopupPage : PopupPage
	{
		ItemOutOfStockPopupPageViewModel viewModel;
		public ItemOutOfStockPopupPage(ItemOutOfStockPopupContext context)
		{
			InitializeComponent();
			lblHeading1.Text = $"If you mark this dish out of stock. It will because hidden on the menu until you update it back to 'In stock'";
			BindingContext = viewModel = new ItemOutOfStockPopupPageViewModel(this.Navigation);
			viewModel.ItemOutOfStockPopupPageContext = context;
		}
	}
}