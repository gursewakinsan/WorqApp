using WorqApp.Service;
using WorqApp.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using Mopups.Services;

namespace WorqApp.ViewModels
{
	public class CleanRoomPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CleanRoomPopupPageViewModel(INavigation navigation)
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
			var responses = await service.AllocateRoomForCleaningAsync(new Models.AllocateRoomForCleaningRequest()
			{
				Id = CleningStaffInfo.Id,
				UserId = Helper.Helper.LoggedInUserId
			});
            await MopupService.Instance.PopAsync();
            CleningStaffInfo.CallBack.Invoke();
			IsBusy = false;
		}
		#endregion

		#region Properties.

		private Models.HotelBookingListForCleningStaffResponse cleningStaffInfo;
		public Models.HotelBookingListForCleningStaffResponse CleningStaffInfo
		{
			get => cleningStaffInfo;
			set
			{
				cleningStaffInfo = value;
				OnPropertyChanged("CleningStaffInfo");
			}
		}
		#endregion
	}
}
