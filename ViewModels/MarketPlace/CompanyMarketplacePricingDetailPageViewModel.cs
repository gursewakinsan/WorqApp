using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class CompanyMarketplacePricingDetailPageViewModel : BaseViewModel
    {
        #region Constructor.
        public CompanyMarketplacePricingDetailPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Company Market Place Pricing Detail Command.
        private ICommand companyMarketplacePricingDetailCommand;
        public ICommand CompanyMarketplacePricingDetailCommand
        {
            get => companyMarketplacePricingDetailCommand ?? (companyMarketplacePricingDetailCommand = new Command(async () => await ExecuteCompanyMarketplacePricingDetailCommand()));
        }
        private async Task ExecuteCompanyMarketplacePricingDetailCommand()
        {
            IsBusy = true;
            IMarketPlaceService service = new MarketPlaceService();
            CompanyMarketplacePricingDetailList = await service.CompanyMarketplacePricingDetailAsync(new Models.CompanyMarketplacePricingDetailRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = Helper.Helper.DomainId,
                ProfessionalSubcategoryId = Helper.Helper.ProfessionalSubcategoryId
            });
            IsBusy = false;
        }
        #endregion

        #region Add New Command.
        private ICommand addNewCommand;
        public ICommand AddNewCommand
        {
            get => addNewCommand ?? (addNewCommand = new Command(async () => await ExecuteAddNewCommand()));
        }
        private async Task ExecuteAddNewCommand()
        {
            Helper.Helper.IsAddNew = true;
            await Navigation.PushAsync(new Views.MarketPlace.SetMarketPricePage());
        }
        #endregion

        #region Properties.
        public List<Models.CompanyMarketplacePricingDetailResponse> companyMarketplacePricingDetailList;
        public List<Models.CompanyMarketplacePricingDetailResponse> CompanyMarketplacePricingDetailList
        {
            get => companyMarketplacePricingDetailList;
            set
            {
                companyMarketplacePricingDetailList = value;
                OnPropertyChanged("CompanyMarketplacePricingDetailList");
            }
        }
        #endregion
    }
}
