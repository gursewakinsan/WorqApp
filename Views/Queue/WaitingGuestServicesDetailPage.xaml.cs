using WorqApp.ViewModels;

namespace WorqApp.Views.Queue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WaitingGuestServicesDetailPage : ContentPage
	{
		WaitingGuestServicesDetailViewModel viewModel;
		public WaitingGuestServicesDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new WaitingGuestServicesDetailViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.QueueGuestDetailCommand.Execute(null);
		}
	}
}