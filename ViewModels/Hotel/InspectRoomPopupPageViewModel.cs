﻿using WorqApp.Service;
using WorqApp.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace WorqApp.ViewModels
{
	public class InspectRoomPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InspectRoomPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Inspect Room Command.
		private ICommand inspectRoomCommand;
		public ICommand InspectRoomCommand
		{
			get => inspectRoomCommand ?? (inspectRoomCommand = new Command(async () => await ExecuteInspectRoomCommand()));
		}
		private async Task ExecuteInspectRoomCommand()
		{
			IsBusy= true;
			IHotelService service = new HotelService();
			var responses = await service.AllocateCheckedOutRoomForInspectionAsync(new Models.AllocateCheckedOutRoomForInspectionRequest()
			{
				RoomId = SelectedIncepectionStaffInfo.RoomId,
				UserId = Helper.Helper.LoggedInUserId
			});
			//await Navigation.PopPopupAsync();
			SelectedIncepectionStaffInfo.CallBack.Invoke();
			IsBusy = false;
		}
		#endregion

		#region Properties.

		private Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse selectedIncepectionStaffInfo;
		public Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse SelectedIncepectionStaffInfo
		{
			get => selectedIncepectionStaffInfo;
			set
			{
				selectedIncepectionStaffInfo = value;
				OnPropertyChanged("SelectedIncepectionStaffInfo");
			}
		}
		#endregion
	}
}
