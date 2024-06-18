using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class BackgrundProposalsInfoDetailsPageViewModel : BaseViewModel
    {
        #region Constructor.
        public BackgrundProposalsInfoDetailsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Get Property Detail Command.
        private ICommand getPropertyDetailCommand;
        public ICommand GetPropertyDetailCommand
        {
            get => getPropertyDetailCommand ?? (getPropertyDetailCommand = new Command(async () => await ExecuteGetPropertyDetailCommand()));
        }
        private async Task ExecuteGetPropertyDetailCommand()
        {
            IsBusy= true;
            IPremiumService service = new PremiumService();
            PropertyDetail = await service.PropertyDetailAsync(new Models.PropertyDetailRequest()
            {
                UserPropertyId = ProposalsInfoDetails.UserPropertyId
            });
            IsBusy = false;
        }
        #endregion

        #region Update Professional Job Status Command.
        private ICommand updateProfessionalJobStatusCommand;
        public ICommand UpdateProfessionalJobStatusCommand
        {
            get => updateProfessionalJobStatusCommand ?? (updateProfessionalJobStatusCommand = new Command<string>(async (jobStatus) => await ExecuteUpdateProfessionalJobStatusCommand(jobStatus)));
        }
        private async Task ExecuteUpdateProfessionalJobStatusCommand(string jobStatus)
        {
            IsBusy= true;
            IPremiumService service = new PremiumService();
            await service.UpdateProfessionalJobStatusAsync(new Models.UpdateProfessionalJobStatusRequest()
            {
                JobId = ProposalsInfoDetails.JobId,
                JobStatus = jobStatus
            });
            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
            IsBusy = false;
        }
        #endregion

        #region Back Command.
        private ICommand backCommand;
        public ICommand BackCommand
        {
            get => backCommand ?? (backCommand = new Command(async () => await ExecuteBackCommand()));
        }
        private async Task ExecuteBackCommand()
        {
            IsBusy= true;
            this.Navigation.RemovePage(this.Navigation.NavigationStack[this.Navigation.NavigationStack.Count - 2]);
            await Navigation.PopAsync();
            IsBusy = false;
        }
        #endregion

        #region Properties.
        private Models.EmployeeProfessionalServiceProposalsResponse proposalsInfoDetails;
        public Models.EmployeeProfessionalServiceProposalsResponse ProposalsInfoDetails
        {
            get => proposalsInfoDetails;
            set
            {
                proposalsInfoDetails = value;
                OnPropertyChanged("ProposalsInfoDetails");
            }
        }

        private Models.EmployeeProfessionalServiceProposalsDatesResponse proposalsDates;
        public Models.EmployeeProfessionalServiceProposalsDatesResponse ProposalsDates
        {
            get => proposalsDates;
            set
            {
                proposalsDates = value;
                OnPropertyChanged("ProposalsDates");
            }
        }

        private Models.PropertyDetailResponse propertyDetail;
        public Models.PropertyDetailResponse PropertyDetail
        {
            get => propertyDetail;
            set
            {
                propertyDetail = value;
                OnPropertyChanged("PropertyDetail");
            }
        }
        #endregion
    }
}
