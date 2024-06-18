using WorqApp.ViewModels;

namespace WorqApp.Views.Hotel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CleanRoomMarkAndSubmitPage : ContentPage
	{
		CleanRoomMarkAndSubmitPageViewModel viewModel;
		public CleanRoomMarkAndSubmitPage (Models.HotelBookingListForCleningStaffResponse staffResponse)
		{
			InitializeComponent ();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CleanRoomMarkAndSubmitPageViewModel(this.Navigation);
			viewModel.CleningStaffInfo = staffResponse;
		}
	}
}