using Mopups.Services;
using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class RemoveTheDishPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public RemoveTheDishPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Delete Dish Item Command.
		private ICommand deleteDishItemCommand;
		public ICommand DeleteDishItemCommand
		{
			get => deleteDishItemCommand ?? (deleteDishItemCommand = new Command(async () => await ExecuteDeleteDishItemCommand()));
		}
		private async Task ExecuteDeleteDishItemCommand()
		{
			IsBusy = true;
			IResturantService service = new ResturantService();
			await service.DeleteDishItemAsync(new Models.DeleteDishItemRequest()
			{
				AvailableDishId = DeleteDishItemPopupPageContext.AvailableDishId,
			});
			IsBusy = false;
            await MopupService.Instance.PopAsync();
            DeleteDishItemPopupPageContext.CallBack.Invoke();
		}
		#endregion

		#region Properties.
		public DeleteDishItemPopupContext DeleteDishItemPopupPageContext { get; set; }
		#endregion
	}
}
