using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = loginViewModel = new LoginViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            //Helper.Helper.SessionId = "N25iNlk5dFVZOUdmaS9sQ0R6d1psRGZndTdON3lPN1RURXcyTUpmb050bz0=";

            if (!string.IsNullOrWhiteSpace(Helper.Helper.SessionId))
                loginViewModel.LoginWithSessionCommand.Execute(null);
            //else
            //loginViewModel.IsAlreadyLoginCommand.Execute(null);
            base.OnAppearing();
        }
    }
}