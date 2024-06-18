using WorqApp.Service;
using WorqApp.Interfaces;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WorqApp.ViewModels
{
    public class CleaningJobsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public CleaningJobsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Team Leader Cleaning Jobs Command.
		private ICommand teamLeaderCleaningJobsCommand;
		public ICommand TeamLeaderCleaningJobsCommand
		{
			get => teamLeaderCleaningJobsCommand ?? (teamLeaderCleaningJobsCommand = new Command(async () => await ExecuteTeamLeaderCleaningJobsCommand()));
		}
		private async Task ExecuteTeamLeaderCleaningJobsCommand()
		{
			IsBusy= true;
			ICleaningJobService service = new CleaningJobService();
			var response = await service.TeamLeaderCleaningJobsAsync(new Models.TeamLeaderCleaningJobsRequest()
			{
				CompanyId = Helper.Helper.CompanyId,
				UserId = Helper.Helper.LoggedInUserId,
				AId = Helper.Helper.ApartmentId
			});

			if (response?.Count > 0)
			{
				foreach (var item in response)
				{
					if (item.CleaningJobStatus == 0)
					{
						item.IsAction = true;
						item.NotClean = true;
						item.CircleBg = Color.FromHex("#F40000");
					}
					else if (item.CleaningJobStatus == 1)
					{
						item.IsAction = true;
						item.CleaningStart = true;
						item.CircleBg = Color.FromHex("#F4B400");
					}
					else if (item.CleaningJobStatus == 2)
					{
						item.IsAction = false;
						item.Cleaned = true;
					}
				}
			}
			CleaningJobs = response;
			IsBusy = false;
		}
		#endregion

		#region Properties.
		private List<Models.TeamLeaderCleaningJobsResponse> cleaningJobs;
		public List<Models.TeamLeaderCleaningJobsResponse> CleaningJobs
		{
			get => cleaningJobs;
			set
			{
				cleaningJobs = value;
				OnPropertyChanged("CleaningJobs");
			}
		}
		#endregion
	}
}