using Mopups.Pages;
using WorqApp.ViewModels;

namespace WorqApp.PopupPages.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InspectedByRoomPopupPage : PopupPage
	{
		InspectedByRoomPopupPageViewModel viewModel;
		public InspectedByRoomPopupPage(Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse staff)
		{
			InitializeComponent();
			BindingContext = viewModel = new InspectedByRoomPopupPageViewModel(this.Navigation);
			if (staff.InspectorId.Equals(Helper.Helper.LoggedInUserId))
				btnCleanedRoom.Text = "Yes, I do";
			else
				btnCleanedRoom.Text = "Got it";
			viewModel.InspectedByRoomInfo = staff;
		}
	}
}