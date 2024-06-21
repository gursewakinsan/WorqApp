using Mopups.Pages;
using WorqApp.ViewModels;

namespace WorqApp.PopupPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RemoveTheDishPopupPage : PopupPage
	{
		RemoveTheDishPopupPageViewModel viewModel;
		public RemoveTheDishPopupPage(DeleteDishItemPopupContext context)
		{
			InitializeComponent();
			BindingContext = viewModel = new RemoveTheDishPopupPageViewModel(this.Navigation);
			viewModel.DeleteDishItemPopupPageContext = context;
		}
	}
}