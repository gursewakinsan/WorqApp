using System.Windows.Input;
using System.Threading.Tasks;
using Mopups.Services;

namespace WorqApp.ViewModels
{
	public class InspectedByRoomPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InspectedByRoomPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Inspected Room Command.
		private ICommand inspectedRoomCommand;
		public ICommand InspectedRoomCommand
		{
			get => inspectedRoomCommand ?? (inspectedRoomCommand = new Command(async () => await ExecuteInspectedRoomCommand()));
		}
		private async Task ExecuteInspectedRoomCommand()
		{
            await MopupService.Instance.PopAsync();
            if (InspectedByRoomInfo.InspectorId.Equals(Helper.Helper.LoggedInUserId))
				InspectedByRoomInfo.CallBack.Invoke();
		}
		#endregion

		#region Properties.

		private Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse inspectedByRoomInfo;
		public Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse InspectedByRoomInfo
		{
			get => inspectedByRoomInfo;
			set
			{
				inspectedByRoomInfo = value;
				OnPropertyChanged("InspectedByRoomInfo");
			}
		}
		#endregion
	}
}
