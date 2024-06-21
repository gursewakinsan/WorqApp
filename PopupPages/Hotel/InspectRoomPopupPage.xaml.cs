using Mopups.Pages;
using WorqApp.ViewModels;

namespace WorqApp.PopupPages.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InspectRoomPopupPage : PopupPage
	{
		InspectRoomPopupPageViewModel viewModel;
		public InspectRoomPopupPage(Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse staff)
		{
			InitializeComponent();
			BindingContext = viewModel = new InspectRoomPopupPageViewModel(this.Navigation);
			viewModel.SelectedIncepectionStaffInfo = staff;
		}
	}
}