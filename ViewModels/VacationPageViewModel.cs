using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class VacationPageViewModel : BaseViewModel
	{
		#region Constructor.
		public VacationPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Update Vacation Info Command.
		private ICommand updateVacationInfoCommand;
		public ICommand UpdateVacationInfoCommand
		{
			get => updateVacationInfoCommand ?? (updateVacationInfoCommand = new Command(async () => await ExecuteUpdateVacationInfoCommand()));
		}
		private async Task ExecuteUpdateVacationInfoCommand()
		{
			if (SelectedStartDate == null)
				await Helper.Alert.DisplayAlert("Start date is required.");
			else if (SelectedEndDate == null)
				await Helper.Alert.DisplayAlert("End date is required.");
			else
			{
				IsBusy = true;
				IAtendenceService service = new AtendenceService();
				int response = await service.UpdateVacationInfoAsync(new Models.UpdateVacationRequest()
				{
					UserId = Helper.Helper.LoggedInUserId,
					CompanyId = Helper.Helper.CompanyId,
					StartDate = $"{SelectedStartDate.Day}/{SelectedStartDate.Month}/{SelectedStartDate.Year}",
					EndDate = $"{SelectedEndDate.Day}/{SelectedEndDate.Month}/{SelectedEndDate.Year}",
					LeaveDescription = LeaveDescription
				});
				await Navigation.PopAsync();
				IsBusy = false;
			}
		}
		#endregion

		#region Properties.
		public DateTime SelectedStartDate { get; set; }
		public DateTime SelectedEndDate { get; set; }
		public DateTime BindMinimumDate => DateTime.Today;
		public DateTime BindMaximumDate => DateTime.Today.AddYears(70);
		public string LeaveDescription { get; set; }
		#endregion
	}
}
