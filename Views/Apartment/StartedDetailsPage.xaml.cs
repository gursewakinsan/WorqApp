using WorqApp.ViewModels;

namespace WorqApp.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartedDetailsPage : ContentPage
    {
        StartedDetailsPageViewModel viewModel;
        public StartedDetailsPage(Models.ApartmentCommunityTicketModel apartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new StartedDetailsPageViewModel(this.Navigation);
            viewModel.SelectedApartmentCommunityTicket = apartment;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApartmentCommunityTicketDetailCommand.Execute(null);
        }
    }
}