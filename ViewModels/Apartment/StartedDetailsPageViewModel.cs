using WorqApp.Service;
using WorqApp.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using WorqApp.Models;

namespace WorqApp.ViewModels
{
    public class StartedDetailsPageViewModel : BaseViewModel
    {
		#region Constructor.
		public StartedDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Finished Button Command.
		private ICommand finishedButtonCommand;
		public ICommand FinishedButtonCommand
		{
			get => finishedButtonCommand ?? (finishedButtonCommand = new Command(async () => await ExecuteFinishedButtonCommand()));
		}
		private async Task ExecuteFinishedButtonCommand()
		{
            IsBusy = true;
            IApartmentService service = new ApartmentService();
			int response = await service.UpdateApartmentCommunityTicketAsync(new Models.UpdateApartmentCommunityTicketRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId,
				Id = SelectedApartmentCommunityTicket.Id,
				TicketStatus = 2
			});
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
            IsBusy = false;
        }
		#endregion

		#region Cancel Button Command.
		private ICommand cancelButtonCommand;
		public ICommand CancelButtonCommand
		{
			get => cancelButtonCommand ?? (cancelButtonCommand = new Command(async () => await ExecuteCancelButtonCommand()));
		}
		private async Task ExecuteCancelButtonCommand()
		{
            IsBusy = true;
            IApartmentService service = new ApartmentService();
			int response = await service.UpdateApartmentCommunityTicketAsync(new Models.UpdateApartmentCommunityTicketRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId,
				Id = SelectedApartmentCommunityTicket.Id,
				TicketStatus = 3
			});
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.SupportPage());
            IsBusy = false;
        }
		#endregion

		#region Finished Command.
		private ICommand finishedCommand;
		public ICommand FinishedCommand
		{
			get => finishedCommand ?? (finishedCommand = new Command(() => ExecuteFinishedCommand()));
		}
		private void ExecuteFinishedCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.FinishPage());
		}
		#endregion

		#region Cancelled Command.
		private ICommand cancelledCommand;
		public ICommand CancelledCommand
		{
			get => cancelledCommand ?? (cancelledCommand = new Command(() => ExecuteCancelledCommand()));
		}
		private void ExecuteCancelledCommand()
		{
			Application.Current.MainPage = new NavigationPage(new Views.Apartment.CancelledPage());
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

		#region Apartment Community Ticket Detail Command.
		private ICommand apartmentCommunityTicketDetailCommand;
		public ICommand ApartmentCommunityTicketDetailCommand
		{
			get => apartmentCommunityTicketDetailCommand ?? (apartmentCommunityTicketDetailCommand = new Command(async () =>await ExecuteApartmentCommunityTicketDetailCommand()));
		}
		private async Task ExecuteApartmentCommunityTicketDetailCommand()
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
        #endregion
    }
}
