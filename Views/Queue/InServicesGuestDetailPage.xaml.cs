using WorqApp.ViewModels;

namespace WorqApp.Views.Queue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InServicesGuestDetailPage : ContentPage
	{
		InServicesGuestDetailViewModel viewModel;
		public InServicesGuestDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new InServicesGuestDetailViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.QueueServicingGuestDetailCommand.Execute(null);
		}
	}
}