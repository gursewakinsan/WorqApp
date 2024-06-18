using System.Linq;
using WorqApp.Service;
using WorqApp.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WorqApp.ViewModels
{
	public class InspectRoomPageViewModel : BaseViewModel
	{
		#region Constructor.
		public InspectRoomPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Incepection Staff Command.
		private ICommand incepectionStaffCommand;
		public ICommand IncepectionStaffCommand
		{
			get => incepectionStaffCommand ?? (incepectionStaffCommand = new Command(async () => await ExecuteIncepectionStaffCommand()));
		}
		private async Task ExecuteIncepectionStaffCommand()
		{
			IsBusy= true;
			IHotelService service = new HotelService();
			var responses = await service.HotelCheckedOutListForHousekeepingIncepectionStaffAsync(new Models.HotelCheckedOutListForHousekeepingIncepectionStaffRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			SearchText = string.Empty;
			IncepectionStaffInfo?.Clear();
			CopyIncepectionStaffInfo?.Clear();
			if (responses != null)
			{
				foreach (var item in responses)
				{
					if (item.InspectionWorkAllocatied)
					{
						item.RoomNameTextColor = Color.FromHex("#FF9129");
						item.RoomNameBgColor = Color.FromHex("#342B20");
						item.RowBorderColor = Color.FromHex("#FF9129");
					}
					else
					{
						item.RoomNameTextColor = Color.FromHex("#4C7CE5");
						item.RoomNameBgColor = Color.FromHex("#242A37");
						item.RowBorderColor = Color.FromHex("#2A2A31");
					}
				}
				CopyIncepectionStaffInfo = responses;
				IncepectionStaffInfo = new ObservableCollection<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse>(responses);
			}
			IsBusy = false;
		}
		#endregion

		#region Search Command.
		private ICommand searchCommand;
		public ICommand SearchCommand
		{
			get => searchCommand ?? (searchCommand = new Command(() => ExecuteSearchCommand()));
		}
		private void ExecuteSearchCommand()
		{
			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				string text = SearchText.ToLower();
				if (CopyIncepectionStaffInfo?.Count > 0)
				{
					var searchResult = CopyIncepectionStaffInfo.Where(x => x.Name.ToLower().Contains(text)).ToList();
					IncepectionStaffInfo = new ObservableCollection<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse>(searchResult);
				}
			}
			else
				IncepectionStaffInfo = new ObservableCollection<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse>(CopyIncepectionStaffInfo);
		}
		#endregion

		#region Go To Inspect Room Popup Page Command.
		private ICommand goToInspectRoomPopupPageCommand;
		public ICommand GoToInspectRoomPopupPageCommand
		{
			get => goToInspectRoomPopupPageCommand ?? (goToInspectRoomPopupPageCommand = new Command(async () => await ExecuteGoToInspectRoomPopupPageCommand()));
		}
		private async Task ExecuteGoToInspectRoomPopupPageCommand()
		{
			SelectedIncepectionStaff.CallBack = CallBackIncepectionStaff;
			//await Navigation.PushPopupAsync(new PopupPages.Hotel.InspectRoomPopupPage(SelectedIncepectionStaff));
		}

		private void CallBackIncepectionStaff()
		{
			IncepectionStaffCommand.Execute(null);
		}
		#endregion

		#region Go To Inspected Room Popup Page Command.
		private ICommand goToInspectedRoomPopupPageCommand;
		public ICommand GoToInspectedRoomPopupPageCommand
		{
			get => goToInspectedRoomPopupPageCommand ?? (goToInspectedRoomPopupPageCommand = new Command(async () => await ExecuteGoToInspectedRoomPopupPageCommand()));
		}
		private async Task ExecuteGoToInspectedRoomPopupPageCommand()
		{
			SelectedIncepectionStaff.CallBack = CallBackInspectedStaff;
			//await Navigation.PushPopupAsync(new PopupPages.Hotel.InspectedByRoomPopupPage(SelectedIncepectionStaff));
		}

		private async void CallBackInspectedStaff()
		{
			await Navigation.PushAsync(new Views.Hotel.InspectCleanedRoomMarkAndSubmitPage(SelectedIncepectionStaff));
		}
		#endregion

		#region Properties.
		public Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse SelectedIncepectionStaff { get; set; }
		public List<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse> CopyIncepectionStaffInfo { get; set; }

		private ObservableCollection<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse> incepectionStaffInfo;
		public ObservableCollection<Models.HotelCheckedOutListForHousekeepingIncepectionStaffResponse> IncepectionStaffInfo
		{
			get => incepectionStaffInfo;
			set
			{
				incepectionStaffInfo = value;
				OnPropertyChanged("IncepectionStaffInfo");
			}
		}

		private string searchText;
		public string SearchText
		{
			get => searchText;
			set
			{
				searchText = value;
				OnPropertyChanged("SearchText");
			}
		}
		#endregion
	}
}
