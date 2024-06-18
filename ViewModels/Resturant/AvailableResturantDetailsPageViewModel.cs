﻿using System.Windows.Input;
using WorqApp.Interfaces;
using WorqApp.Service;

namespace WorqApp.ViewModels
{
    public class AvailableResturantDetailsPageViewModel : BaseViewModel
	{
		#region Constructor.
		public AvailableResturantDetailsPageViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion

		#region Resturant Serve Based Menu Command.
		private ICommand resturantServeBasedMenuCommand;
		public ICommand ResturantServeBasedMenuCommand
		{
			get => resturantServeBasedMenuCommand ?? (resturantServeBasedMenuCommand = new Command(async () => await ExecuteResturantServeBasedMenuCommand()));
		}
		private async Task ExecuteResturantServeBasedMenuCommand()
		{
			IsBusy= true;
			IResturantService service = new ResturantService();
			ResturantServeInfo = AvailableResturantDetails.ServeTypes.FirstOrDefault(x => x.IsSelectedServe);
			int deviceWidth = App.ScreenWidth - 56;
			int imgWidth = deviceWidth * 40 / 100;
			int imgHeight = imgWidth * 97 / 100;

			ResturantServeBasedMenuInfo = await service.ResturantServeBasedMenuAsync(new Models.ResturantServeBasedMenuRequest()
			{
				ResturantId = AvailableResturantDetails.Id,
				ServeType = ResturantServeInfo.Id,
				ImgHeight = imgHeight,
				ImgWidth = imgWidth
			});
			IsBusy = false;
		}
		#endregion

		#region Properties.
		private List<Models.ResturantServeBasedMenuResponse> resturantServeBasedMenuInfo;
		public List<Models.ResturantServeBasedMenuResponse> ResturantServeBasedMenuInfo
		{
			get => resturantServeBasedMenuInfo;
			set
			{
				resturantServeBasedMenuInfo = value;
				OnPropertyChanged("ResturantServeBasedMenuInfo");
			}
		}

		private Models.ServeType resturantServeInfo;
		public Models.ServeType ResturantServeInfo
		{ 
			get => resturantServeInfo;
			set
			{
				resturantServeInfo = value;
				OnPropertyChanged("ResturantServeInfo");
			}
		}

		private Models.AvailableResturantResponse availableResturantDetails;
		public Models.AvailableResturantResponse AvailableResturantDetails
		{
			get => availableResturantDetails;
			set
			{
				availableResturantDetails = value;
				OnPropertyChanged("AvailableResturantDetails");
			}
		}
		#endregion
	}
}