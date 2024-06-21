using Mopups.Services;
using System.Windows.Input;
using WorqApp.Helper;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Constructor.
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Is Already Login Command.
        private ICommand isAlreadyLoginCommand;
        public ICommand IsAlreadyLoginCommand
        {
            get => isAlreadyLoginCommand ?? (isAlreadyLoginCommand = new Command(async () => await ExecuteIsAlreadyLoginCommand()));
        }
        private async Task ExecuteIsAlreadyLoginCommand()
        {
            IsBusy = true;
            string userId = await SecureStorage.Default.GetAsync("UserId");
            if (!string.IsNullOrWhiteSpace(userId))
            {
                Helper.Helper.LoggedInUserId = Convert.ToInt32(userId);
                Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
            }
            IsBusy = false;
        }
        #endregion

        #region Login Command.
        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get => loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
        }
        private async Task ExecuteLoginCommand()
        {
            if (string.IsNullOrWhiteSpace(Username))
                await Alert.DisplayAlert("Username is required");
            else if (string.IsNullOrWhiteSpace(Password))
                await Alert.DisplayAlert("Password is required");
            else
            {
                IsBusy = true;
                Models.LoginRequest model = new Models.LoginRequest()
                {
                    Username = Username,
                    Password = Password
                };
                ILoginService service = new LoginService();
                var response = await service.LoginAsync(model);
                if (response.Id > 0)
                {
                    Helper.Helper.LoggedInUserId = response.Id;

                    string userId = await SecureStorage.Default.GetAsync("UserId");
                    if (!string.IsNullOrWhiteSpace(userId))
                        _ = SecureStorage.Default.Remove("UserId");
                    await SecureStorage.Default.SetAsync("UserId", response.Id.ToString());

                    Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
                }
                else
                    await Alert.DisplayAlert("Invalid Username or Password.");
                IsBusy = false;
            }
        }
        #endregion

        #region Login With Session Command.
        private ICommand loginWithSessionCommand;
        public ICommand LoginWithSessionCommand
        {
            get => loginWithSessionCommand ?? (loginWithSessionCommand = new Command(async () => await ExecuteLoginWithSessionCommand()));
        }
        private async Task ExecuteLoginWithSessionCommand()
        {
            IsBusy = true;
            ILoginService service = new LoginService();
            /*Models.InterAppSessionResponse response = await service.LoginWithSessionAsync(new Models.InterAppSessionRequest()
            {
                Session = Helper.Helper.SessionId
            });*/
            Models.InterAppSessionResponse response = new Models.InterAppSessionResponse()
            {
                Result = 1,
                UserId = 21,
                FirstName = "Chandan",
                LastName = "Jain"
            };
            if (response == null)
                await Alert.DisplayAlert("Something went wrong, Please try after some time.");
            else if (response.Result == 0)
                await Alert.DisplayAlert("You have enter wrong password, Please try again.");
            else if (response.Result == 1)
            {
                Helper.Helper.LoggedInUserId = response.UserId;
                Helper.Helper.FirstName = response.FirstName;
                Helper.Helper.LastName = response.LastName;
                IDashboardService dashboardService = new DashboardService();
                var companies = await dashboardService.GetCompaniesByIdAsync(Helper.Helper.LoggedInUserId);
                if (companies == null)
                    Application.Current.MainPage = new NavigationPage(new Views.NoCompanyPage());
                else if (companies.Count == 0)
                    Application.Current.MainPage = new NavigationPage(new Views.NoCompanyPage());
                else if (companies.Count == 1)
                {
                    Helper.Helper.CompanyId = companies[0].CompanyId;
                    Helper.Helper.CompanyName = companies[0].CompanyName;
                    Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
                }
                else if (companies.Count > 1)
                    Application.Current.MainPage = new NavigationPage(new Views.DashboardPage());
            }
            IsBusy = false;
        }
        #endregion

        #region Login With QloudId App Command.
        private ICommand loginWithQloudIdAppCommand;
        public ICommand LoginWithQloudIdAppCommand
        {
            get => loginWithQloudIdAppCommand ?? (loginWithQloudIdAppCommand = new Command(async () => await ExecuteLoginWithQloudIdAppCommand()));
        }
        private async Task ExecuteLoginWithQloudIdAppCommand()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                //var supportsUri = await Launcher.CanOpenAsync("QloudidUrl://");
                //if (supportsUri)
                await Launcher.OpenAsync("QloudidUrl://NoffaPlusApp");
                //else
                //await Alert.DisplayAlert("QloudID app not install on your mobile phone.");
            }
            else
            {
                var supportsUri = await Launcher.CanOpenAsync("https://qloudid.com/ip/");
                if (supportsUri)
                    await Launcher.OpenAsync("https://qloudid.com/ip/");
                else
                    await Alert.DisplayAlert("QloudID app not install on your mobile phone.");
            }
            await Task.CompletedTask;
        }
        #endregion

        #region Properties.
        public string Username { get; set; } //= "qloudsuperagent2@qualeefy.com"; //= "qloudsuperagent1@qloudid.com";
        public string Password { get; set; } //= "av#ng3rs";
        #endregion
    }
}
