using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformMissingChildrenPage : ContentPage
	{
		public InformMissingChildrenPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = new InformMissingChildrenViewModel(this.Navigation);
		}
	}
}