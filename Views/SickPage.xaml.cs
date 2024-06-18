using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SickPage : ContentPage
	{
		SickPageViewModel viewModel;
		public SickPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new SickPageViewModel(this.Navigation);
		}
	}
}