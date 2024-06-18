using WorqApp.ViewModels;

namespace WorqApp.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetMarketPricePage : ContentPage
    {
        SetMarketPricePageViewModel ViewModel;
        public SetMarketPricePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new SetMarketPricePageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.GetWorkingHrsCommand.Execute(null);
        }
    }
}