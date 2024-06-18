using System.Windows.Input;
using WorqApp.Helper;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class CompanyDetailsViewModel : BaseViewModel
    {
        #region Constructor.
        public CompanyDetailsViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Admin Command.
        private ICommand adminCommand;
        public ICommand AdminCommand
        {
            get => adminCommand ?? (adminCommand = new Command(async () => await ExecuteAdminCommand()));
        }
        private async Task ExecuteAdminCommand()
        {
            await Navigation.PushAsync(new Views.AdminInfoPage());
        }
        #endregion

        #region App Store Command.
        private ICommand appStoreCommand;
        public ICommand AppStoreCommand
        {
            get => appStoreCommand ?? (appStoreCommand = new Command(async () => await ExecuteAppStoreCommand()));
        }
        private async Task ExecuteAppStoreCommand()
        {
            IsBusy = true;
            IQueueService service = new QueueService();
            var response = await service.GetOperatorQueueAsync(new Models.OperatorQueueRequest()
            {
                UserId = Helper.Helper.LoggedInUserId,
                CompanyId = Helper.Helper.CompanyId
            });
            if (response?.Count > 0)
                await Navigation.PushAsync(new Views.Queue.OperatorQueueListPage());
            IsBusy = false;
        }
        #endregion

        #region Verify Admin Command.
        private ICommand verifyAdminCommand;
        public ICommand VerifyAdminCommand
        {
            get => verifyAdminCommand ?? (verifyAdminCommand = new Command(async () => await ExecuteVerifyAdminCommand()));
        }
        private async Task ExecuteVerifyAdminCommand()
        {
            if (CompanyDetail != null) return;
            IsBusy = true;
            Models.VerifyAdminRequest request = new Models.VerifyAdminRequest()
            {
                UserId = Helper.Helper.LoggedInUserId,
                CompanyId = Helper.Helper.CompanyId
            };
            ICompanyService service = new CompanyService();

            Models.DaycareResponse response = await service.DaycareRequestCountAsync(new Models.DaycareRequest()
            {
                CompanyId = Helper.Helper.CompanyId
            });

            var daycareList = new List<Models.Daycare>();
            daycareList.Add(new Models.Daycare() { Id = 0, Heading = "Time", IconColor = Color.FromRgba("#FF0000"), HeadingIcon = NoffaPlusAppFlatIcons.AlarmNote, SubHeading = "Stamp when you start and get off work" });
            daycareList.Add(new Models.Daycare() { Id = 1, Heading = "Landloard", IconColor = Color.FromRgba("#000000"), HeadingIcon = NoffaPlusAppFlatIcons.Home, SubHeading = "Please check your landloard request here" });
            daycareList.Add(new Models.Daycare() { Id = 2, Heading = "SafeQid", IconColor = Color.FromRgba("#4287f5"), HeadingIcon = NoffaPlusAppFlatIcons.HumanChild, SubHeading = "Confirm presence of a checked-in child" });
            daycareList.Add(new Models.Daycare() { Id = 3, Heading = "SafeQid", IconColor = Color.FromRgba("#4287f5"), HeadingIcon = NoffaPlusAppFlatIcons.HumanChild, SubHeading = "Confirm pick up request/s" });

            if (response.Inactive == 0)
                daycareList.Add(new Models.Daycare() { Id = 4, Heading = "SafeQid", IconColor = Color.FromRgba("#4287f5"), HeadingIcon = NoffaPlusAppFlatIcons.HumanChild, SubHeading = "Register parents to children" });
            else
                daycareList.Add(new Models.Daycare() { Id = 4, Heading = "SafeQid", IconColor = Color.FromRgba("#4287f5"), HeadingIcon = NoffaPlusAppFlatIcons.HumanChild, SubHeading = $"Register parents to {response.Inactive} children" });

            if (response.DunsIsApproved == 0)
                daycareList.Add(new Models.Daycare() { Id = 5, Heading = "DUNS number", IconColor = Color.FromRgba("#4287f5"), HeadingIcon = NoffaPlusAppFlatIcons.AccountTie, SubHeading = "Register DUNS for verification" });
            else
                daycareList.Add(new Models.Daycare() { Id = 5, Heading = "DUNS number", IconColor = Color.FromRgba("#4287f5"), HeadingIcon = NoffaPlusAppFlatIcons.AccountTie, SubHeading = "DUNS already verified" });

            DaycareList = daycareList;

            CompanyDetail = await service.VerifyAdminAsync(request);
            IsBusy = false;
        }
        #endregion

        #region Children Missing Command.
        private ICommand childrenMissingCommand;
        public ICommand ChildrenMissingCommand
        {
            get => childrenMissingCommand ?? (childrenMissingCommand = new Command(async () => await ExecuteChildrenMissingCommand()));
        }
        private async Task ExecuteChildrenMissingCommand()
        {
            await Navigation.PushAsync(new Views.ChildrenMissingListPage());
        }
        #endregion

        #region Attendance Command.
        private ICommand attendanceCommand;
        public ICommand AttendanceCommand
        {
            get => attendanceCommand ?? (attendanceCommand = new Command(async () => await ExecuteAttendanceCommand()));
        }
        private async Task ExecuteAttendanceCommand()
        {
            IsBusy= true;
            IAtendenceService service = new AtendenceService();
            int response = await service.EmployeeAtendenceAsync(new Models.EmployeeAtendenceRequest()
            {
                UserId = Helper.Helper.LoggedInUserId,
                CompanyId = Helper.Helper.CompanyId
            });
            if (response == 0)
                await Navigation.PushAsync(new Views.AttendancePage());
            else if (response == 1)
                await Navigation.PushAsync(new Views.AttendanceTimerPage());
            IsBusy = false;
        }
        #endregion

        #region Apartment Connect Command.
        private ICommand apartmentConnectCommand;
        public ICommand ApartmentConnectCommand
        {
            get => apartmentConnectCommand ?? (apartmentConnectCommand = new Command(async () => await ExecuteApartmentConnectCommand()));
        }
        private async Task ExecuteApartmentConnectCommand()
        {
            await Navigation.PushAsync(new Views.Landloard.ApartmentConnectRequestPage());
        }
        #endregion

        #region Scan QR Command.
        private ICommand scanQrCommand;
        public ICommand ScanQrCommand
        {
            get => scanQrCommand ?? (scanQrCommand = new Command<string>(async (qrCode) => await ExecuteScanQrCommand(qrCode)));
        }
        private async Task ExecuteScanQrCommand(string qrCode)
        {
            IsBusy= true;
            string[] ip = qrCode.Split('/');
            if (ip.Length == 3)
            {
                if (ip[2].Equals("verify_hotel_staff"))
                {
                    IpFromQr = ip[0];
                    Helper.Helper.HotelId = ip[1];
                    VerifEmployeeInfoCommand.Execute(null);
                }
                else if (ip[0].Equals("verify_checkin"))
                {
                    Helper.Helper.ApartmentId = ip[2];
                    await Navigation.PushAsync(new Views.ServiceHomePage());
                }
            }
            IsBusy = false;
            await Task.CompletedTask;
        }
        #endregion

        #region Verif Employee Info Command.
        private ICommand verifEmployeeInfoCommand;
        public ICommand VerifEmployeeInfoCommand
        {
            get => verifEmployeeInfoCommand ?? (verifEmployeeInfoCommand = new Command(async () => await ExecuteVerifEmployeeInfoCommand()));
        }
        private async Task ExecuteVerifEmployeeInfoCommand()
        {
            IsBusy= true;
            IVerifyHotelStaffService service = new VerifyHotelStaffService();
            int response = await service.VerifEmployeeInfoAsync(new Models.VerifEmployeeInfoRequest()
            {
                HotelId = Helper.Helper.HotelId,
                IpFromQr = IpFromQr,
                CompanyId = Helper.Helper.CompanyId,
                UserId = Helper.Helper.LoggedInUserId
            });
            if (response == 0)
                Application.Current.MainPage = new NavigationPage(new Views.VerifyHotelStaff.NotAuthorizedForVerifyHotelStaffPage());
            else if (response == 1)
                await Navigation.PushAsync(new Views.VerifyHotelStaff.GenerateKeyForInstaBoxPage());
            IsBusy = false;
        }
        #endregion

        #region Properties.
        public string IpFromQr { get; set; }

        private Models.VerifyAdminResponse companyDetail;
        public Models.VerifyAdminResponse CompanyDetail
        {
            get => companyDetail;
            set
            {
                companyDetail = value;
                OnPropertyChanged("CompanyDetail");
            }
        }

        public string DisplayCompanyName => Helper.Helper.CompanyName;

        public List<Models.Daycare> daycareList;
        public List<Models.Daycare> DaycareList
        {
            get => daycareList;
            set
            {
                daycareList = value;
                OnPropertyChanged("DaycareList");
            }
        }
        #endregion
    }
}
