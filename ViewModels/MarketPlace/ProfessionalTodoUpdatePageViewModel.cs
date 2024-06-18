﻿using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class ProfessionalTodoUpdatePageViewModel : BaseViewModel
    {
        #region Constructor.
        public ProfessionalTodoUpdatePageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ProfessionalTodoUpdateList = new List<Models.ProfessionalTodoUpdateModel>()
            {
                new Models.ProfessionalTodoUpdateModel()
                {
                    Name = "Services",
                    TextIcon = Helper.NoffaPlusAppFlatIcons.CarEstate
                },
                new Models.ProfessionalTodoUpdateModel()
                {
                    Name = "Pricing",
                    TextIcon = Helper.NoffaPlusAppFlatIcons.CartOutline
                },
                new Models.ProfessionalTodoUpdateModel()
                {
                    Name = "Languages",
                    TextIcon = Helper.NoffaPlusAppFlatIcons.MessageOutline
                },
                new Models.ProfessionalTodoUpdateModel()
                {
                    Name = "Area",
                    TextIcon = Helper.NoffaPlusAppFlatIcons.Home
                },
            };
        }
        #endregion

        #region Professional Todo Update Command.
        private ICommand professionalTodoUpdateCommand;
        public ICommand ProfessionalTodoUpdateCommand
        {
            get => professionalTodoUpdateCommand ?? (professionalTodoUpdateCommand = new Command(async () => await ExecuteProfessionalTodoUpdateCommand()));
        }
        private async Task ExecuteProfessionalTodoUpdateCommand()
        {
            IsBusy= true;
            IMarketPlaceService service = new MarketPlaceService();
            await service.ProfessionalTodoUpdateAsync(new Models.ProfessionalTodoUpdateRequest()
            {
                CompanyId = Helper.Helper.CompanyId,
                DomainId = SelectedCompanyMarketplace.Id
            });
            IsBusy = false;
        }
        #endregion

        #region Properties.
        public Models.CompanyMarketplaceListResponse selectedCompanyMarketplace;
        public Models.CompanyMarketplaceListResponse SelectedCompanyMarketplace
        {
            get => selectedCompanyMarketplace;
            set
            {
                selectedCompanyMarketplace = value;
                OnPropertyChanged("SelectedCompanyMarketplace");
            }
        }

        public List<Models.ProfessionalTodoUpdateModel> professionalTodoUpdateList;
        public List<Models.ProfessionalTodoUpdateModel> ProfessionalTodoUpdateList
        {
            get => professionalTodoUpdateList;
            set
            {
                professionalTodoUpdateList = value;
                OnPropertyChanged("ProfessionalTodoUpdateList");
            }
        }
        #endregion
    }
}
