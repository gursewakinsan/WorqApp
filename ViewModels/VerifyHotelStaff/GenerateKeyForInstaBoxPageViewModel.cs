﻿using System.Timers;
using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class GenerateKeyForInstaBoxPageViewModel : BaseViewModel
	{
		#region Local Variable.
		System.Timers.Timer timer;
		int count = 1;
		#endregion

		#region Constructor.
		public GenerateKeyForInstaBoxPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			timer = new System.Timers.Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 30000;
			timer.Enabled = true;
		}
		#endregion

		#region On Timed Event.
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			if (count == 8)
			{
				count = 1;
				timer.Stop();
				timer.Enabled = false;
				ReleaseHotelInstaboxCommand.Execute(null);
			}
			else
			{
				count = count + 1;
				timer.Start();
			}
		}
		#endregion

		#region Release Hotel Instabox Command.
		private ICommand releaseHotelInstaboxCommand;
		public ICommand ReleaseHotelInstaboxCommand
		{
			get => releaseHotelInstaboxCommand ?? (releaseHotelInstaboxCommand = new Command(async () => await ExecuteReleaseHotelInstaboxCommand()));
		}
		private async Task ExecuteReleaseHotelInstaboxCommand()
		{
			IsBusy = true;
			IVerifyHotelStaffService service = new VerifyHotelStaffService();
			await service.ReleaseHotelInstaboxAsync(new Models.HotelBookingInstaBoxListForKeyGenerationRequest()
			{
				HotelId = Helper.Helper.HotelId
			});
			Device.BeginInvokeOnMainThread(() =>
			{
				Application.Current.MainPage = new NavigationPage(new Views.VerifyHotelStaff.SessionExpiredForVerifyHotelStaffPage());
			});
			IsBusy = false;
		}
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(async () => await ExecuteBackCommand()));
		}
		private async Task ExecuteBackCommand()
		{
			if (timer.Enabled)
			{
				timer.Stop();
				timer.Enabled = false;
				IsBusy = true;
				IVerifyHotelStaffService service = new VerifyHotelStaffService();
				await service.ReleaseHotelInstaboxAsync(new Models.HotelBookingInstaBoxListForKeyGenerationRequest()
				{
					HotelId = Helper.Helper.HotelId
				});
				IsBusy = false;
			}
			await Navigation.PopAsync();
		}
		#endregion

		#region Hotel Booking List For Key Generation Command.
		private ICommand hotelBookingListForKeyGenerationCommand;
		public ICommand HotelBookingListForKeyGenerationCommand
		{
			get => hotelBookingListForKeyGenerationCommand ?? (hotelBookingListForKeyGenerationCommand = new Command(async () => await ExecuteHotelBookingListForKeyGenerationCommand()));
		}
		private async Task ExecuteHotelBookingListForKeyGenerationCommand()
		{
			IsBusy = true;
			IVerifyHotelStaffService service = new VerifyHotelStaffService();
			HotelBookingListForKeyGenerationInfo = await service.HotelBookingListForKeyGenerationAsync(new Models.HotelBookingListForKeyGenerationRequest()
			{
				HotelId = Helper.Helper.HotelId
			});

			HotelBookingInstaBoxListForKeyGenerationInfo = await service.HotelBookingInstaBoxListForKeyGenerationAsync(new Models.HotelBookingInstaBoxListForKeyGenerationRequest()
			{
				HotelId = Helper.Helper.HotelId
			});
			IsBusy = false;
		}
		#endregion

		#region Get Available Rooms Command.
		private ICommand getAvailableRoomsCommand;
		public ICommand GetAvailableRoomsCommand
		{
			get => getAvailableRoomsCommand ?? (getAvailableRoomsCommand = new Command<int>(async (index) => await ExecuteGetAvailableRoomsCommand(index)));
		}
		private async Task ExecuteGetAvailableRoomsCommand(int index)
		{
			IsBusy = true;
			IVerifyHotelStaffService service = new VerifyHotelStaffService();
			AvailableRoomsInfo = await service.GetAvailableRoomsAsync(new Models.GetAvailableRoomsRequest()
			{
				CheckoutId = HotelBookingListForKeyGenerationInfo[index].Id
			});
			IsBusy = false;
		}
		#endregion

		#region Submit Generate Key For Insta Box Command.
		private ICommand submitGenerateKeyForInstaBoxCommand;
		public ICommand SubmitGenerateKeyForInstaBoxCommand
		{
			get => submitGenerateKeyForInstaBoxCommand ?? (submitGenerateKeyForInstaBoxCommand = new Command(async () => await ExecuteSubmitGenerateKeyForInstaBoxCommand()));
		}
		private async Task ExecuteSubmitGenerateKeyForInstaBoxCommand()
		{
			if (SelectedBookingConfirmationCode == null)
				await Helper.Alert.DisplayAlert("Please select booking confirmation code.");
			else if (SelectedRoomInfo == null)
				await Helper.Alert.DisplayAlert("Please select room.");
			else if (SelectedAvailableBox == null)
				await Helper.Alert.DisplayAlert("Please select available box.");
			else
			{
				if (timer.Enabled)
				{
					timer.Stop();
					timer.Enabled = false;
				}
				IsBusy = true;
				IVerifyHotelStaffService service = new VerifyHotelStaffService();
				var response = await service.GenerateKeyForInstaBoxAsync(new Models.GenerateKeyForInstaBoxRequest()
				{
					BookingId = SelectedBookingConfirmationCode.Id,
					InstaBoxId = SelectedAvailableBox.Id,
					HotelId = Helper.Helper.HotelId,
					RoomId = SelectedRoomInfo.Id
				});
				Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
				IsBusy = false;
			}
		}
		#endregion

		#region Properties.
		private List<Models.HotelBookingListForKeyGenerationResponse> hotelBookingListForKeyGenerationInfo;
		public List<Models.HotelBookingListForKeyGenerationResponse> HotelBookingListForKeyGenerationInfo
		{
			get => hotelBookingListForKeyGenerationInfo;
			set
			{
				hotelBookingListForKeyGenerationInfo = value;
				OnPropertyChanged("HotelBookingListForKeyGenerationInfo");
			}
		}

		private Models.HotelBookingListForKeyGenerationResponse selectedBookingConfirmationCode;
		public Models.HotelBookingListForKeyGenerationResponse SelectedBookingConfirmationCode
		{
			get => selectedBookingConfirmationCode;
			set
			{
				selectedBookingConfirmationCode = value;
				OnPropertyChanged("SelectedBookingConfirmationCode");
			}
		}

		private List<Models.HotelBookingInstaBoxListForKeyGenerationResponse> hotelBookingInstaBoxListForKeyGenerationInfo;
		public List<Models.HotelBookingInstaBoxListForKeyGenerationResponse> HotelBookingInstaBoxListForKeyGenerationInfo
		{
			get => hotelBookingInstaBoxListForKeyGenerationInfo;
			set
			{
				hotelBookingInstaBoxListForKeyGenerationInfo = value;
				OnPropertyChanged("HotelBookingInstaBoxListForKeyGenerationInfo");
			}
		}

		private List<Models.GetAvailableRoomsResponse> availableRoomsInfo;
		public List<Models.GetAvailableRoomsResponse> AvailableRoomsInfo
		{
			get => availableRoomsInfo;
			set
			{
				availableRoomsInfo = value;
				OnPropertyChanged("AvailableRoomsInfo");
			}
		}

		private Models.GetAvailableRoomsResponse selectedRoomInfo;
		public Models.GetAvailableRoomsResponse SelectedRoomInfo
		{
			get => selectedRoomInfo;
			set
			{
				selectedRoomInfo = value;
				OnPropertyChanged("SelectedRoomInfo");
			}
		}
		

		private Models.HotelBookingInstaBoxListForKeyGenerationResponse selectedAvailableBox;
		public Models.HotelBookingInstaBoxListForKeyGenerationResponse SelectedAvailableBox
		{
			get => selectedAvailableBox;
			set
			{
				selectedAvailableBox = value;
				OnPropertyChanged("SelectedAvailableBox");
			}
		}
		#endregion
	}
}
