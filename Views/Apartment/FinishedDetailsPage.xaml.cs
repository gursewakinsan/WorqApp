using WorqApp.ViewModels;

namespace WorqApp.Views.Apartment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FinishedDetailsPage : ContentPage
	{
		FinishedDetailsPageViewModel viewModel;
		public FinishedDetailsPage (Models.ApartmentCommunityTicketModel apartment)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new FinishedDetailsPageViewModel(this.Navigation);
			viewModel.SelectedApartmentCommunityTicket = apartment;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.ApartmentCommunityTicketDetailCommand.Execute(null);
		}
	}
}