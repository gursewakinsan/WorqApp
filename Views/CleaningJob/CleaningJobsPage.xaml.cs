using WorqApp.ViewModels;

namespace WorqApp.Views.CleaningJob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CleaningJobsPage : ContentPage
    {
        CleaningJobsPageViewModel viewModel;
        public CleaningJobsPage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new CleaningJobsPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.TeamLeaderCleaningJobsCommand.Execute(null);
        }

        async void OnCleaningJobsItemTapped(System.Object sender, ItemTappedEventArgs e)
        {
            Models.TeamLeaderCleaningJobsResponse item = e.Item as Models.TeamLeaderCleaningJobsResponse;
            listCleaningJobs.SelectedItem = null;
            Helper.Helper.SelectedCleaningJob = item.Id;
            if (item.CleaningJobStatus == 1)
                await Navigation.PushAsync(new RegularFinishedCleaningTasksPage());
            else if (item.CleaningJobStatus == 0)
                await Navigation.PushAsync(new CleaningTasksPage());
        }
    }
}
