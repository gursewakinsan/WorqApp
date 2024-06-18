using WorqApp.ViewModels;

namespace WorqApp.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompanyMarketplacePricingDetailPage : ContentPage
    {
        CompanyMarketplacePricingDetailPageViewModel ViewModel;
        public CompanyMarketplacePricingDetailPage(string subCategoryName)
        {
            InitializeComponent(); 
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new CompanyMarketplacePricingDetailPageViewModel(this.Navigation);
            lblHeading.Text = subCategoryName;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.CompanyMarketplacePricingDetailCommand.Execute(null);
        }
    }
}