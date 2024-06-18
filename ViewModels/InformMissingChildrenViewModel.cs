using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class InformMissingChildrenViewModel : BaseViewModel
	{
		#region Constructor.
		public InformMissingChildrenViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Inform To Employees.
		private ICommand informToEmployeesCommand;
		public ICommand InformToEmployeesCommand
		{
			get => informToEmployeesCommand ?? (informToEmployeesCommand = new Command(async () => await ExecuteInformToEmployeesCommand()));
		}
		private async Task ExecuteInformToEmployeesCommand()
		{
			IsBusy= true;
			IChildrenService service = new ChildrenService();
			var response = await service.InformToEmployeesForMissingChildrenAsync(Helper.Helper.CompanyId);
			var _lastPage = Navigation.NavigationStack.LastOrDefault();
			Navigation.RemovePage(_lastPage);
			IsBusy = false;
			await Navigation.PopAsync();
		}
		#endregion
	}
}
