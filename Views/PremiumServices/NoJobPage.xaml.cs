using WorqApp.ViewModels;

namespace WorqApp.Views.PremiumServices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoJobPage : ContentPage
    {
        NoJobPageViewModel viewModel;
        public NoJobPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NoJobPageViewModel(this.Navigation);
        }
    }
}