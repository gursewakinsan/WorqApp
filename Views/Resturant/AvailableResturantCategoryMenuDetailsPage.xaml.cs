using WorqApp.ViewModels;

namespace WorqApp.Views.Resturant
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvailableResturantCategoryMenuDetailsPage : ContentPage
	{
		AvailableResturantCategoryMenuDetailsPageViewModel viewModel;
		public AvailableResturantCategoryMenuDetailsPage (Models.Dish dish)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AvailableResturantCategoryMenuDetailsPageViewModel(this.Navigation);
			viewModel.DishDetailsInfo = dish;
			viewModel.IsItemInStock = dish.TempAvailableItem;
		}
	}
}