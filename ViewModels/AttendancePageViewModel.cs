﻿using System.Timers;
using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class AttendancePageViewModel : BaseViewModel
	{
        #region Local Variable.
        System.Timers.Timer timer;
		#endregion

		#region Constructor.
		public AttendancePageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			timer = new System.Timers.Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 60000;
			timer.Enabled = true;
		}
		#endregion

		#region On Timed Event.
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			DisplayCurrentTime = DateTime.Now.ToString("HH:mm");
			DisplayCurrentDate = DateTime.Now.Date.ToString("dddd - MMMM dd");
			timer.Start();
		}
		#endregion

		#region Go To Attendance Timer Page Command.
		private ICommand goToAttendanceTimerPageCommand;
		public ICommand GoToAttendanceTimerPageCommand
		{
			get => goToAttendanceTimerPageCommand ?? (goToAttendanceTimerPageCommand = new Command(async () => await ExecuteGoToAttendanceTimerPageCommand()));
		}
		private async Task ExecuteGoToAttendanceTimerPageCommand()
		{
            IsBusy = true;
            IAtendenceService service = new AtendenceService();
			int response = await service.UpdateAttendenceAsync(new Models.EmployeeAtendenceRequest()
			{
				UserId = Helper.Helper.LoggedInUserId,
				CompanyId = Helper.Helper.CompanyId
			});
			await Navigation.PushAsync(new Views.AttendanceTimerPage());
            IsBusy = false;
        }
		#endregion

		#region Go To Sick Page Command.
		private ICommand goToSickPageCommand;
		public ICommand GoToSickPageCommand
		{
			get => goToSickPageCommand ?? (goToSickPageCommand = new Command(async () => await ExecuteGoToSickPageCommand()));
		}
		private async Task ExecuteGoToSickPageCommand()
		{
			await Navigation.PushAsync(new Views.SickPage());
		}
		#endregion

		#region Go To Vacation Page Command.
		private ICommand goToVacationPageCommand;
		public ICommand GoToVacationPageCommand
		{
			get => goToVacationPageCommand ?? (goToVacationPageCommand = new Command(async () => await ExecuteGoToVacationPageCommand()));
		}
		private async Task ExecuteGoToVacationPageCommand()
		{
			await Navigation.PushAsync(new Views.VacationPage());
		}
		#endregion

		#region Properties.
		private string displayCurrentTime = DateTime.Now.ToString("HH:mm");
		public string DisplayCurrentTime
		{
			get => displayCurrentTime;
			set
			{
				displayCurrentTime = value;
				OnPropertyChanged("DisplayCurrentTime");
			}
		}

		private string displayCurrentDate = DateTime.Now.Date.ToString("dddd - MMMM dd");
		public string DisplayCurrentDate
		{
			get => displayCurrentDate;
			set
			{
				displayCurrentDate = value;
				OnPropertyChanged("DisplayCurrentDate");
			}
		}
		#endregion
	}
}
