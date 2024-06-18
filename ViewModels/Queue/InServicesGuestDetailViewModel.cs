using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class InServicesGuestDetailViewModel : BaseViewModel
	{
		#region Constructor.
		public InServicesGuestDetailViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Queue Servicing Guest Detail Command.
		private ICommand queueServicingGuestDetailCommand;
		public ICommand QueueServicingGuestDetailCommand
		{
			get => queueServicingGuestDetailCommand ?? (queueServicingGuestDetailCommand = new Command(async () => await ExecuteQueueServicingGuestDetailCommand()));
		}
		private async Task ExecuteQueueServicingGuestDetailCommand()
		{
			IsBusy= true;
			IQueueService service = new QueueService();
			QueueServicingGuestDetail = await service.QueueServicingGuestDetailAsync(new Models.QueueGuestRequest()
			{
				GuestId = Helper.Helper.QueueGuestId
			});

			if (QueueServicingGuestDetail.ServingUserId.Equals(Helper.Helper.LoggedInUserId))
			{
				AddedBy = "Self";
				IsVisibleDone = true;
			}
			else
			{
				AddedBy = QueueServicingGuestDetail.UserServing;
				IsVisibleDone = false;
			}
			IsBusy = false;
		}
		#endregion

		#region Done Command.
		private ICommand doneCommand;
		public ICommand DoneCommand
		{
			get => doneCommand ?? (doneCommand = new Command(async () => await ExecuteDoneCommand()));
		}
		private async Task ExecuteDoneCommand()
		{
			IsBusy= true;
			IQueueService service = new QueueService();
			int response = await service.UpdateCloseServiceAsync(new Models.QueueGuestRequest()
			{
				GuestId = Helper.Helper.QueueGuestId
			});
			if (response == 1)
				Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorQueueDetailPage());
			else
				await Helper.Alert.DisplayAlert("Something went wrong please try again.");
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
			Helper.Helper.SelectedTabQueueText = "Waiting";
			await Navigation.PopAsync();
			//Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorStatusQueueListPage());
			//await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private Models.QueueServicingGuestDetailResponse queueServicingGuestDetail;
		public Models.QueueServicingGuestDetailResponse QueueServicingGuestDetail
		{
			get => queueServicingGuestDetail;
			set
			{
				queueServicingGuestDetail = value;
				OnPropertyChanged("QueueServicingGuestDetail");
			}
		}

		private bool isVisibleDone;
		public bool IsVisibleDone
		{
			get => isVisibleDone;
			set
			{
				isVisibleDone = value;
				OnPropertyChanged("IsVisibleDone");
			}
		}

		private string addedBy;
		public string AddedBy
		{
			get => addedBy;
			set
			{
				addedBy = value;
				OnPropertyChanged("AddedBy");
			}
		}

		public string TodayDate => DateTime.Now.ToString("dd MMMM");
		public string TodayTime => DateTime.Now.ToString("h:mm tt");
		#endregion
	}
}
