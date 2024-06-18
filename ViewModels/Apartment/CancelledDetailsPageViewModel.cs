using WorqApp.Service;
using WorqApp.Interfaces;
using System.Windows.Input;
using WorqApp.Models;

namespace WorqApp.ViewModels
{
    public class CancelledDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public CancelledDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Apartment Community Ticket Detail Command.
		private ICommand apartmentCommunityTicketDetailCommand;
		public ICommand ApartmentCommunityTicketDetailCommand
		{
			get => apartmentCommunityTicketDetailCommand ?? (apartmentCommunityTicketDetailCommand = new Command(() => ExecuteApartmentCommunityTicketDetailCommand()));
		}
		private async void ExecuteApartmentCommunityTicketDetailCommand()
		{
			IsBusy = true;
			IApartmentService service = new ApartmentService();
			var response = await service.ApartmentCommunityTicketDetailAsync(new Models.ApartmentCommunityTicketDetailRequest()
			{
				Id = SelectedApartmentCommunityTicket.Id
			});
			if (response.Images?.Count == 0)
			{
				IsApartmentNoImageAvailable = true;
			}
			else if (response.Images?.Count == 1)
			{
				IsApartmentNoImageAvailable = false;
				int deviceWidth = App.ScreenWidth - 56;
				foreach (var item in response.Images)
					item.ItemWidth = deviceWidth;
			}

			else if (response.Images?.Count > 1)
			{
				IsApartmentNoImageAvailable = false;
				int deviceWidth = App.ScreenWidth - 56;
				int imgWidth = deviceWidth * 85 / 100;
				foreach (var item in response.Images)
					item.ItemWidth = imgWidth;
			}
			ApartmentCommunityTicketDetail = response;
            IsBusy = false;
        }
		#endregion

		#region Start This Button Command.
		private ICommand startThisButtonCommand;
		public ICommand StartThisButtonCommand
		{
			get => startThisButtonCommand ?? (startThisButtonCommand = new Command(() => ExecuteStartThisButtonCommand()));
		}
		private async void ExecuteStartThisButtonCommand()
		{
            IsBusy = true;
            IApartmentService service = new ApartmentService();
			int response = await service.UpdateApartmentCommunityTicketAsync(new Models.UpdateApartmentCommunityTicketRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId,
				Id = SelectedApartmentCommunityTicket.Id,
				TicketStatus = 1
			});
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
            IsBusy = false;
        }
		#endregion

		#region Back Command.
		private ICommand backCommand;
		public ICommand BackCommand
		{
			get => backCommand ?? (backCommand = new Command(() => ExecuteBackCommand()));
		}
		private void ExecuteBackCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
		}
		#endregion

		#region Properties.
		private Models.ApartmentCommunityTicketDetailResponse apartmentCommunityTicketDetail;
		public Models.ApartmentCommunityTicketDetailResponse ApartmentCommunityTicketDetail
		{
			get => apartmentCommunityTicketDetail;
			set
			{
				apartmentCommunityTicketDetail = value;
				OnPropertyChanged("ApartmentCommunityTicketDetail");
			}
		}

		private bool isApartmentNoImageAvailable = false;
		public bool IsApartmentNoImageAvailable
		{
			get => isApartmentNoImageAvailable;
			set
			{
				isApartmentNoImageAvailable = value;
				OnPropertyChanged("IsApartmentNoImageAvailable");
			}
		}
		public ApartmentCommunityTicketModel SelectedApartmentCommunityTicket { get; set; }
		public string DisplayApartmentName => Helper.Helper.ApartmentCommunityTicketInfo.ApartmentName;
		#endregion
	}
}
