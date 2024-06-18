using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AttendancePage : ContentPage
	{
		AttendancePageViewModel viewModel;
		public AttendancePage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new AttendancePageViewModel(this.Navigation);
		}
	}
}