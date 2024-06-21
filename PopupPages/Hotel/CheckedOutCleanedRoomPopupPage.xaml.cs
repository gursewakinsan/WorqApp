using Mopups.Pages;
using WorqApp.ViewModels;

namespace WorqApp.PopupPages.Hotel
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckedOutCleanedRoomPopupPage : PopupPage
	{
		CheckedOutCleanedRoomPopupPageViewModel viewModel;
		public CheckedOutCleanedRoomPopupPage(Models.HotelCheckedOutListForCleningStaffResponse staff)
		{
			InitializeComponent();
			BindingContext = viewModel = new CheckedOutCleanedRoomPopupPageViewModel(this.Navigation);
			if (staff.StaffAssignedId.Equals(Helper.Helper.LoggedInUserId))
				btnCleanedRoom.Text = "Yes, I do";
			else
				btnCleanedRoom.Text = "Got it";
			viewModel.CheckedOutCleningStaffInfo = staff;
		}
	}
}