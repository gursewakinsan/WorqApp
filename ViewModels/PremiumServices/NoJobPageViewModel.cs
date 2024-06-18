using System.Windows.Input;

namespace WorqApp.ViewModels
{
    public class NoJobPageViewModel : BaseViewModel
    {
        #region Constructor.
        public NoJobPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Create New Job Command.
        private ICommand createNewJobCommand;
        public ICommand CreateNewJobCommand
        {
            get => createNewJobCommand ?? (createNewJobCommand = new Command(async () => await ExecuteCreateNewJobCommand()));
        }
        private async Task ExecuteCreateNewJobCommand()
        {
            //await Navigation.PushAsync(new Views.PremiumServices.CreateNewJobPage());
        }
        #endregion
    }
}
