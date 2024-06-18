using WorqApp.ViewModels;

namespace WorqApp.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupportPage : ContentPage
    {
        SupportPageViewModel viewModel;
        public SupportPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new SupportPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ApartmentCommunityTicketListCommand.Execute(null);
        }
    }
}