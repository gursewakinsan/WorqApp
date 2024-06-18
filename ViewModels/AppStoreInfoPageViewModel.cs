using System.Collections.ObjectModel;
using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class AppStoreInfoPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AppStoreInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Get Company Downloaded Apps Command.
		private ICommand getCompanyDownloadedAppsCommand;
		public ICommand GetCompanyDownloadedAppsCommand
		{
			get => getCompanyDownloadedAppsCommand ?? (getCompanyDownloadedAppsCommand = new Command(async () => await ExecuteGetCompanyDownloadedAppsCommand()));
		}
		private async Task ExecuteGetCompanyDownloadedAppsCommand()
		{
			IsBusy = true;
			Models.CompanyDownloadedAppsRequest request = new Models.CompanyDownloadedAppsRequest()
			{
				CompanyId = Helper.Helper.CompanyId
			};
			ICompanyService service = new CompanyService();
			var response = await service.CompanyDownloadedAppsAsync(request);
			CompanyDownloadedApps = new ObservableCollection<Models.CompanyDownloadedAppsResponse>(response);
			IsBusy = false;
		}
		#endregion
		 
		#region Is HotelCommand.
		private ICommand isHotelCommand;
		public ICommand IsHotelCommand
		{
			get => isHotelCommand ?? (isHotelCommand = new Command(async () => await ExecuteIsHotelCommand()));
		}
		private async Task ExecuteIsHotelCommand()
		{
			IsBusy= true;
			IHotelService service = new HotelService();
			int response = await service.IsHotelAsync(new Models.HotelBookingRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId
			});
			if (response == 1)
				await Navigation.PushAsync(new Views.Hotel.HotelBookingStayInfoPage());
			IsBusy = false;
		}
		#endregion

		#region Properties.
		private ObservableCollection<Models.CompanyDownloadedAppsResponse> companyDownloadedApps;
		public ObservableCollection<Models.CompanyDownloadedAppsResponse> CompanyDownloadedApps
		{
			get => companyDownloadedApps;
			set
			{
				companyDownloadedApps = value;
				OnPropertyChanged("CompanyDownloadedApps");
			}
		}
		#endregion
	}
}
