using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChildrenMissingListPage : ContentPage
	{
		ChildrenMissingListViewModel childrenMissingListViewModel;
		public ChildrenMissingListPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = childrenMissingListViewModel = new ChildrenMissingListViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			childrenMissingListViewModel.GetChildrenMissingCommand.Execute(null);
			base.OnAppearing();
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			Image image = sender as Image;
			childrenMissingListViewModel.SelectedChildrenMissingCommand.Execute(Convert.ToInt32(image.ClassId));
		}
	}
}