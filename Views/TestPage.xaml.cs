using WorqApp.ViewModels;

namespace WorqApp.Views
{
    public partial class TestPage : ContentPage
    {
        TestPageViewModel viewModel;
        public TestPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new TestPageViewModel(this.Navigation);
        }
    }
}
