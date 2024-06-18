using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class ProposalsInfoDetailsPageViewModel : BaseViewModel
    {
        #region Constructor.
        public ProposalsInfoDetailsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region Backgrund Proposals Info Details Command.
        private ICommand backgrundProposalsInfoDetailsCommand;
        public ICommand BackgrundProposalsInfoDetailsCommand
        {
            get => backgrundProposalsInfoDetailsCommand ?? (backgrundProposalsInfoDetailsCommand = new Command(async () => await ExecuteBackgrundProposalsInfoDetailsCommand()));
        }
        private async Task ExecuteBackgrundProposalsInfoDetailsCommand()
        {
            await Navigation.PushAsync(new Views.PremiumServices.BackgrundProposalsInfoDetailsPage(ProposalsInfoDetails, ProposalsDates));
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
        #endregion
    }
}