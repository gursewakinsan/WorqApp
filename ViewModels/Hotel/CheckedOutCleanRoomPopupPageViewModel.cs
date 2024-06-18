﻿using WorqApp.Service;
using WorqApp.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace WorqApp.ViewModels
{
	public class CheckedOutCleanRoomPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CheckedOutCleanRoomPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Clean Room Command.
		private ICommand cleanRoomCommand;
		public ICommand CleanRoomCommand
		{
			get => cleanRoomCommand ?? (cleanRoomCommand = new Command(async () => await ExecuteCleanRoomCommand()));
		}
		private async Task ExecuteCleanRoomCommand()
		{
			IsBusy= true;
			IHotelService service = new HotelService();
			var responses = await service.AllocateCheckedOutRoomForCleaningAsync(new Models.AllocateCheckedOutRoomForCleaningRequest()
			{
				RoomId = CheckedOutCleningStaffInfo.RoomId,
				UserId = Helper.Helper.LoggedInUserId
			});
			//await Navigation.PopPopupAsync();
			CheckedOutCleningStaffInfo.CallBack.Invoke();
			IsBusy = false;
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
