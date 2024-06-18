using WorqApp.ViewModels;

namespace WorqApp.Views.PremiumServices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BackgrundProposalsInfoDetailsPage : ContentPage
    {
        BackgrundProposalsInfoDetailsPageViewModel viewModel;
        public BackgrundProposalsInfoDetailsPage(Models.EmployeeProfessionalServiceProposalsResponse proposalsInfo, Models.EmployeeProfessionalServiceProposalsDatesResponse dates)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new BackgrundProposalsInfoDetailsPageViewModel(this.Navigation);
            viewModel.ProposalsInfoDetails = proposalsInfo;
            viewModel.ProposalsDates = dates;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetPropertyDetailCommand.Execute(null);
        }
    }
}