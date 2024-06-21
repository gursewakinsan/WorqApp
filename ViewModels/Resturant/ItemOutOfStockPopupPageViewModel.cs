using Mopups.Services;
using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class ItemOutOfStockPopupPageViewModel : BaseViewModel
	{
		#region Constructor.
		public ItemOutOfStockPopupPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Item Out Of Stock Command.
		private ICommand itemOutOfStockCommand;
		public ICommand ItemOutOfStockCommand
		{
			get => itemOutOfStockCommand ?? (itemOutOfStockCommand = new Command(async () => await ExecuteItemOutOfStockCommand()));
		}
		private async Task ExecuteItemOutOfStockCommand()
		{
            IsBusy = true;
            IResturantService service = new ResturantService();
			await service.UpdateDishStockAsync(new Models.UpdateDishStockRequest()
			{
				AvailableDishId = ItemOutOfStockPopupPageContext.AvailableDishId,
				InStock = 0
			});
            IsBusy = false;
            await MopupService.Instance.PopAsync();
            ItemOutOfStockPopupPageContext.CallBack.Invoke();
		}
		#endregion

		#region Properties.
		public ItemOutOfStockPopupContext ItemOutOfStockPopupPageContext { get; set; }
		#endregion
	}
}
