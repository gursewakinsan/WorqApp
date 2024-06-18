using WorqApp.ViewModels;

namespace WorqApp.Views.Hotel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InspectCleanedRoomMarkAndSubmitPage : ContentPage
	{
		InspectCleanedRoomMarkAndSubmitPageViewModel viewModel;
		public InspectCleanedRoomMarkAndSubmitPage(Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse staff)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InspectCleanedRoomMarkAndSubmitPageViewModel(this.Navigation);
			viewModel.SelectedInspectedStaffInfo = staff;
		}
	}
}