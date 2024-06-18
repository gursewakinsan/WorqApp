using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class AreaDetailPageViewModel : BaseViewModel
    {
        #region Constructor.
        public AreaDetailPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Get Area Detail Command.
        private ICommand getAreaDetailCommand;
        public ICommand GetAreaDetailCommand
        {
            get => getAreaDetailCommand ?? (getAreaDetailCommand = new Command(async () => await ExecuteGetAreaDetailCommand()));
        }
        private async Task ExecuteGetAreaDetailCommand()
        {
            IsBusy= true;
            IMarketPlaceService service = new MarketPlaceService();
            AreaDetailList = await service.SelectedAreaDetailAsync(new Models.SelectedAreaDetailRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId
            });
            IsBusy = false;
        }
        #endregion

        #region Update Area Detail Command.
        private ICommand updateAreaDetailCommand;
        public ICommand UpdateAreaDetailCommand
        {
            get => updateAreaDetailCommand ?? (updateAreaDetailCommand = new Command(async () => await ExecuteUpdateAreaDetailCommand()));
        }
        private async Task ExecuteUpdateAreaDetailCommand()
        {
            IsBusy= true;
            IMarketPlaceService service = new MarketPlaceService();
            await service.UpdateAreaAsync(new Models.UpdateAreaRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId,
                AreaId = AreaId
            });
            IsBusy = false;
        }
        #endregion

        #region Properties.
        public int AreaId { get; set; }

        public List<Models.SelectedAreaDetailResponse> areaDetailList;
        public List<Models.SelectedAreaDetailResponse> AreaDetailList
        {
            get => areaDetailList;
            set
            {
                areaDetailList = value;
                OnPropertyChanged("AreaDetailList");
            }
        }
        #endregion
    }
}
