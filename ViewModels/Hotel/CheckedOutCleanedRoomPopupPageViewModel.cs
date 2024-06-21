using System.Windows.Input;
using System.Threading.Tasks;
using Mopups.Services;

namespace WorqApp.ViewModels
{
	public class CheckedOutCleanedRoomPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckedOutCleanedRoomPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cleaned Room Command.
		private ICommand cleanedRoomCommand;
		public ICommand CleanedRoomCommand
		{
			get => cleanedRoomCommand ?? (cleanedRoomCommand = new Command(async () => await ExecuteCleanedRoomCommand()));
		}
		private async Task ExecuteCleanedRoomCommand()
		{
            await MopupService.Instance.PopAsync();
            if (CheckedOutCleningStaffInfo.StaffAssignedId.Equals(Helper.Helper.LoggedInUserId))
				CheckedOutCleningStaffInfo.CallBack.Invoke();
		}
		#endregion

		#region Properties.

		private Models.HotelCheckedOutListForCleningStaffResponse checkedOutCleningStaffInfo;
		public Models.HotelCheckedOutListForCleningStaffResponse CheckedOutCleningStaffInfo
		{
			get => checkedOutCleningStaffInfo;
			set
			{
				checkedOutCleningStaffInfo = value;
				OnPropertyChanged("CheckedOutCleningStaffInfo");
			}
		}
		#endregion
	}
}
