using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class MarketPlaceListPageViewModel : BaseViewModel
    {
        #region Constructor.
        public MarketPlaceListPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Company Market place List Command.
        private ICommand companyMarketplaceListCommand;
        public ICommand CompanyMarketplaceListCommand
        {
            get => companyMarketplaceListCommand ?? (companyMarketplaceListCommand = new Command(async () => await ExecuteCompanyMarketplaceListCommand()));
        }
        private async Task ExecuteCompanyMarketplaceListCommand()
        {
            IsBusy= true;
            IMarketPlaceService service = new MarketPlaceService();
            CompanyMarketplaceList = await service.CompanyMarketplaceListAsync(new Models.CompanyMarketplaceListRequest()
            {
                CompanyId = Helper.Helper.CompanyId
            });
            IsBusy = false;
        }
        #endregion

        #region Properties.
        public List<Models.CompanyMarketplaceListResponse> companyMarketplaceList;
        public List<Models.CompanyMarketplaceListResponse> CompanyMarketplaceList
        {
            get => companyMarketplaceList;
            set
            {
                companyMarketplaceList = value;
                OnPropertyChanged("CompanyMarketplaceList");
            }
        }
        #endregion
    }
}
