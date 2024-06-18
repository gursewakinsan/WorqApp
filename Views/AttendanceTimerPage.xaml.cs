using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttendanceTimerPage : ContentPage
	{
		AttendanceTimerPageViewModel viewModel;
		public AttendanceTimerPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AttendanceTimerPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.CheckEmployeeTimeCommand.Execute(null);
		}
	}
}