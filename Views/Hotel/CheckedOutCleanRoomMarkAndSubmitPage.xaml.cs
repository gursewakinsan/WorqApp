using WorqApp.ViewModels;

namespace WorqApp.Views.Hotel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckedOutCleanRoomMarkAndSubmitPage : ContentPage
	{
		CheckedOutCleanRoomMarkAndSubmitPageViewModel viewModel;
		public CheckedOutCleanRoomMarkAndSubmitPage(Models.HotelCheckedOutListForCleningStaffResponse staffResponse)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new CheckedOutCleanRoomMarkAndSubmitPageViewModel(this.Navigation);
			viewModel.CheckedOutCleningStaffInfo = staffResponse;
		}
	}
}