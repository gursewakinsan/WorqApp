﻿using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class WaitingGuestServicesDetailViewModel : BaseViewModel
	{
		#region Constructor.
		public WaitingGuestServicesDetailViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Queue Guest Detail Command.
		private ICommand queueGuestDetailCommand;
		public ICommand QueueGuestDetailCommand
		{
			get => queueGuestDetailCommand ?? (queueGuestDetailCommand = new Command(async () => await ExecuteQueueGuestDetailCommand()));
		}
		private async Task ExecuteQueueGuestDetailCommand()
		{
            IsBusy = true;
            IQueueService service = new QueueService();
			QueueGuestDetail = await service.QueueGuestDetailAsync(new Models.QueueGuestRequest()
			{
				GuestId = Helper.Helper.QueueGuestId
			});
            IsBusy = false;
        }
		#endregion

		#region Now Show Command.
		private ICommand nowShowCommand;
		public ICommand NowShowCommand
		{
			get => nowShowCommand ?? (nowShowCommand = new Command(async () => await ExecuteNowShowCommand()));
		}
		private async Task ExecuteNowShowCommand()
		{
            IsBusy = true;
            IQueueService service = new QueueService();
			int response = await service.UpdateNoShowAsync(new Models.QueueGuestRequest()
			{
				GuestId = Helper.Helper.QueueGuestId
			});
			if (response == 1)
			{
				Helper.Helper.SelectedTabQueueText = "Waiting";
				//Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorStatusQueueListPage());
				await Navigation.PopAsync();
			}
			else
				await Helper.Alert.DisplayAlert("Something went wrong please try again.");
            IsBusy = false;
        }
		#endregion

		#region Alert Command.
		private ICommand alertCommand;
		public ICommand AlertCommand
		{
			get => alertCommand ?? (alertCommand = new Command(async () => await ExecuteAlertCommand()));
		}
		private async Task ExecuteAlertCommand()
		{
            IsBusy = true;
            IQueueService service = new QueueService();
			int response = await service.AlertGuestAsync(new Models.QueueGuestRequest()
			{
				GuestId = Helper.Helper.QueueGuestId
			});
			if (response == 1)
			{
				Helper.Helper.SelectedTabQueueText = "Waiting";
				//Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorStatusQueueListPage());
				await Navigation.PopAsync();
			}
			else
				await Helper.Alert.DisplayAlert("Something went wrong please try again.");
            IsBusy = false;
        }
		#endregion

		#region Serve Command.
		private ICommand serveCommand;
		public ICommand ServeCommand
		{
			get => serveCommand ?? (serveCommand = new Command(async () => await ExecuteServeCommand()));
		}
		private async Task ExecuteServeCommand()
		{
            IsBusy = true;
            IQueueService service = new QueueService();
			int response = await service.UpdateInServicingAsync(new Models.UpdateInServicingRequest()
			{
				GuestId = Helper.Helper.QueueGuestId,
				UserId = Helper.Helper.LoggedInUserId
			});
			if (response == 1)
			{
				Helper.Helper.SelectedTabQueueText = "In service";
				//Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorStatusQueueListPage());
				await Navigation.PopAsync();
			}
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
			await Navigation.PopAsync();
			//Application.Current.MainPage = new NavigationPage(new Views.Queue.OperatorStatusQueueListPage());
			//await Task.CompletedTask;
		}
		#endregion

		#region Properties.
		private Models.QueueGuestDetailResponse queueGuestDetail;
		public Models.QueueGuestDetailResponse QueueGuestDetail
		{
			get => queueGuestDetail;
			set
			{
				queueGuestDetail = value;
				OnPropertyChanged("QueueGuestDetail");
			}
		}

		public string TodayDate => DateTime.Now.ToString("dd MMMM");
		public string TodayTime => DateTime.Now.ToString("h:mm tt");
		#endregion
	}
}
