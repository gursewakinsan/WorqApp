using System.Timers;

namespace WorqApp.ViewModels
{
    public class TestPageViewModel : BaseViewModel
    {
		#region Local Variable.
		System.Timers.Timer timer;
		int count = 1;
		#endregion

		#region Constructor.
		public TestPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
			timer = new System.Timers.Timer();
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			timer.Interval = 30000;
			timer.Enabled = true;
		}
		#endregion

		#region On Timed Event.
		private async void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			if (count == 2)
			{
				count = 1;
				timer.Stop();
				timer.Enabled = false;
				DisplayTimeInfo = count;

				Device.BeginInvokeOnMainThread(() =>
				{
					//DependencyService.Get<IProgressBar>().Show();
					//IVerifyHotelStaffService service = new VerifyHotelStaffService();
					//await service.ReleaseHotelInstaboxAsync(new Models.HotelBookingInstaBoxListForKeyGenerationRequest()
					//{
						//HotelId = Helper.Helper.HotelId
					//});
					Application.Current.MainPage = new NavigationPage(new Views.VerifyHotelStaff.SessionExpiredForVerifyHotelStaffPage());
					//IsBusy = false;
				});
				
			}
			else
			{
				count = count + 1;
				timer.Start();
				DisplayTimeInfo = count;
			}
		}
		#endregion

		private int displayTimeInfo;
		public int DisplayTimeInfo
		{
			get => displayTimeInfo;
			set
			{
				displayTimeInfo = value;
				OnPropertyChanged("DisplayTimeInfo");
			}
		}
	}
}
