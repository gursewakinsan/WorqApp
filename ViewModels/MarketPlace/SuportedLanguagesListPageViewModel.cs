using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class SuportedLanguagesListPageViewModel : BaseViewModel
    {
        #region Constructor.
        public SuportedLanguagesListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Suported Languages List Command.
        private ICommand suportedLanguagesListCommand;
        public ICommand SuportedLanguagesListCommand
        {
            get => suportedLanguagesListCommand ?? (suportedLanguagesListCommand = new Command(async () => await ExecuteSuportedLanguagesListCommand()));
        }
        private async Task ExecuteSuportedLanguagesListCommand()
        {
            IsBusy= true;
            IMarketPlaceService service = new MarketPlaceService();
            SuportedLanguagesList = await service.SuportedLanguagesListAsync(new Models.SuportedLanguagesListRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId
            });
            IsBusy = false;
        }
        #endregion

        #region Update Language Available Command.
        private ICommand updateLanguageAvailableCommand;
        public ICommand UpdateLanguageAvailableCommand
        {
            get => updateLanguageAvailableCommand ?? (updateLanguageAvailableCommand = new Command(async () => await ExecuteUpdateLanguageAvailableCommand()));
        }
        private async Task ExecuteUpdateLanguageAvailableCommand()
        {
            IsBusy= true;
            IMarketPlaceService service = new MarketPlaceService();
            await service.UpdateLanguageAvailableAsync(new Models.UpdateLanguageAvailableRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId,
                LanguageId = LanguageId
            });
            IsBusy = false;
        }
        #endregion

        #region Properties.
        public int LanguageId { get; set; }
        public List<Models.SuportedLanguagesListResponse> suportedLanguagesList;
        public List<Models.SuportedLanguagesListResponse> SuportedLanguagesList
        {
            get => suportedLanguagesList;
            set
            {
                suportedLanguagesList = value;
                OnPropertyChanged("SuportedLanguagesList");
            }
        }
        #endregion
    }
}
