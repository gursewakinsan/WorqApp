using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiceHomePage : ContentPage
    {
        ServiceHomePageViewModel viewModel;
        public ServiceHomePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new ServiceHomePageViewModel(this.Navigation);
        }
    }
}
