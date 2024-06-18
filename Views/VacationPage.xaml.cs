using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VacationPage : ContentPage
	{
		VacationPageViewModel viewModel;
		public VacationPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new VacationPageViewModel(this.Navigation);
		}
	}
}