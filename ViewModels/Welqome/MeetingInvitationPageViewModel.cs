using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class MeetingInvitationPageViewModel : BaseViewModel
	{
		#region Constructor.
		public MeetingInvitationPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			SelectedDate = DateTime.Today;
			//SelectedTime = DateTime.Now.TimeOfDay;
		}
		#endregion

		#region Get All Country Code Command.
		private ICommand getAllCountryCodeCommand;
		public ICommand GetAllCountryCodeCommand
		{
			get => getAllCountryCodeCommand ?? (getAllCountryCodeCommand = new Command(async () => await ExecuteGetAllCountryCodeCommand()));
		}
		private async Task ExecuteGetAllCountryCodeCommand()
		{
			IsBusy = true;
			IAdminService service = new AdminService();
			CountryCodeList = await service.CountryCodeListAsync();
			IsBusy = false;
		}
		#endregion

		#region Invite Visitor Command.
		private ICommand inviteVisitorCommand;
		public ICommand InviteVisitorCommand
		{
			get => inviteVisitorCommand ?? (inviteVisitorCommand = new Command(async () => await ExecuteInviteVisitorCommand()));
		}
		private async Task ExecuteInviteVisitorCommand()
		{
			if (SelectedDate == null)
				await Helper.Alert.DisplayAlert("Please select date");
			else if (SelectedTime == null)
				await Helper.Alert.DisplayAlert("Please select time");
			else if (string.IsNullOrWhiteSpace(FullName))
				await Helper.Alert.DisplayAlert("Name is required.");
			/*else if (!string.IsNullOrWhiteSpace(EmailAddress))
			{
				if (!Helper.Helper.IsValid(EmailAddress))
					await Helper.Alert.DisplayAlert("Please enter valid email address.");
			}*/
			else if (SelectedCountryCode == null)
				await Helper.Alert.DisplayAlert("Please select Code.");
			else if (string.IsNullOrWhiteSpace(PhoneNumber))
				await Helper.Alert.DisplayAlert("Phone number is required.");
			else
			{
				IsBusy = true;
				Models.InviteVisitorRequest request = new Models.InviteVisitorRequest()
				{
					UserId = Helper.Helper.LoggedInUserId,
					CompanyId = Helper.Helper.CompanyId,
					VDate = SelectedDate,
					VTime = SelectedTime,
					Name = FullName,
					Email = EmailAddress,
					CountryId = SelectedCountryCode.Id,
					Phone = PhoneNumber
				};
				IAdminService service = new AdminService();
				await service.InviteVisitorAsync(request);
				await Navigation.PopAsync();
				IsBusy = false;
			}
		}
		#endregion

		#region Properties.
		private List<Models.CountryCodeListResponse> countryCodeList;
		public List<Models.CountryCodeListResponse> CountryCodeList
		{
			get => countryCodeList;
			set
			{
				countryCodeList = value;
				OnPropertyChanged("CountryCodeList");
			}
		}

		private string fullName;
		public string FullName
		{
			get => fullName;
			set
			{
				fullName = value;
				OnPropertyChanged("FullName");
			}
		}

		private string emailAddress;
		public string EmailAddress
		{
			get => emailAddress;
			set
			{
				emailAddress = value;
				OnPropertyChanged("EmailAddress");
			}
		}

		private string phoneNumber;
		public string PhoneNumber
		{
			get => phoneNumber;
			set
			{
				phoneNumber = value;
				OnPropertyChanged("PhoneNumber");
			}
		}

		public DateTime SelectedDate { get; set; }
		public DateTime BindMinimumDate => DateTime.Today;
		public DateTime BindMaximumDate => DateTime.Today.AddYears(70);
		public TimeSpan SelectedTime { get; set; }
		public Models.CountryCodeListResponse SelectedCountryCode { get; set; }
		#endregion
	}
}
