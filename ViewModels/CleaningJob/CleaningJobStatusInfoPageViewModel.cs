using WorqApp.Service;
using WorqApp.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;

namespace WorqApp.ViewModels
{
    public class CleaningJobStatusInfoPageViewModel : BaseViewModel
    {
		#region Constructor.
		public CleaningJobStatusInfoPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Cleaning Job Status Info Command.
		private ICommand cleaningJobStatusInfoCommand;
		public ICommand CleaningJobStatusInfoCommand
		{
			get => cleaningJobStatusInfoCommand ?? (cleaningJobStatusInfoCommand = new Command(async () => await ExecuteCleaningJobStatusInfoCommand()));
		}
		private async Task ExecuteCleaningJobStatusInfoCommand()
		{
			IsBusy= true;
			ICleaningJobService service = new CleaningJobService();
			CleaningJobStatusInfo = await service.CleaningJobStatusInfoAsync(new Models.CleaningJobStatusInfoRequest()
			{
				CleaningJobId = Helper.Helper.SelectedCleaningJob
			});
			IsBusy = false;
		}
		#endregion

		#region Update Cleaning Final Status Command.
		private ICommand updateCleaningFinalStatusCommand;
		public ICommand UpdateCleaningFinalStatusCommand
		{
			get => updateCleaningFinalStatusCommand ?? (updateCleaningFinalStatusCommand = new Command(async () => await ExecuteUpdateCleaningFinalStatusCommand()));
		}
		private async Task ExecuteUpdateCleaningFinalStatusCommand()
		{
			IsBusy= true;
			ICleaningJobService service = new CleaningJobService();
			await service.UpdateCleaningFinalStatusAsync(new Models.UpdateCleaningFinalStatusRequest()
			{
				CleaningJobId = Helper.Helper.SelectedCleaningJob,
				IfRentable = IsRentable
			});
			Application.Current.MainPage = new NavigationPage(new Views.CompanyDetailsPage());
			IsBusy = false;
		}
		#endregion

		#region Properties.
		private Models.CleaningJobStatusInfoResponse cleaningJobStatusInfo;
		public Models.CleaningJobStatusInfoResponse CleaningJobStatusInfo
		{
			get => cleaningJobStatusInfo;
			set
			{
				cleaningJobStatusInfo = value;
				OnPropertyChanged("CleaningJobStatusInfo");
			}
		}

        public int IsRentable { get; set; }
        #endregion
    }
}
