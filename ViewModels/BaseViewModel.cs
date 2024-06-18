using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace WorqApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Property.
        public INavigation Navigation { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }
        #endregion

        #region On Property Changed.
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Close Command.
        private ICommand closeCommand;
        public ICommand CloseCommand
        {
            get => closeCommand ?? (closeCommand = new Command(async () => await ExecuteCloseCommand()));
        }
        private async Task ExecuteCloseCommand()
        {
            await Navigation.PopAsync();
        }
        #endregion
    }
}
