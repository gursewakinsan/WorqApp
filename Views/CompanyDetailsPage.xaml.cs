﻿using WorqApp.ViewModels;
using ZXing.Net.Maui.Controls;

namespace WorqApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CompanyDetailsPage : ContentPage
	{
		CompanyDetailsViewModel companyDetailsViewModel;
		CameraBarcodeReaderView scanPage;
		int carouselViewPosition = 0;
		public CompanyDetailsPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = companyDetailsViewModel = new CompanyDetailsViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			companyDetailsViewModel.VerifyAdminCommand.Execute(null);
			base.OnAppearing();
		}

		private void OnGestureRecognizerTapped(object sender, EventArgs e)
		{
			StackLayout layout = sender as StackLayout;
            OnItemTapped(Convert.ToInt32(layout.ClassId));
        }

		private void GridOnGestureRecognizerTapped(object sender, EventArgs e)
		{
			Grid layout = sender as Grid;
            OnItemTapped(Convert.ToInt32(layout.ClassId));
        }

		private void LabelOnGestureRecognizerTapped(object sender, EventArgs e)
		{
			Label layout = sender as Label;
			OnItemTapped(Convert.ToInt32(layout.ClassId));
		}

		void OnItemTapped(int id)
		{
			if (id == 0)
				companyDetailsViewModel.AttendanceCommand.Execute(null);
			else if (id == 1)
				companyDetailsViewModel.ApartmentConnectCommand.Execute(null);
		}

        private void OnCarouselViewPositionChanged(object sender, PositionChangedEventArgs e)
		{
			carouselViewPosition = e.CurrentPosition;
			Color color = companyDetailsViewModel.DaycareList[carouselViewPosition].IconColor;
			indicatorView.SelectedIndicatorColor = color;
			btnLearnMore.TextColor = color;
		}

		private void OnLearnMoreButtonClicked(object sender, EventArgs e)
		{
			if (carouselViewPosition == 0)
				companyDetailsViewModel.AttendanceCommand.Execute(null);
		}

		private async void OnScanQrClicked(object sender, EventArgs e)
		{
			var customOverlay = new Grid();

			var back = new ImageButton
			{
				Margin = new Thickness(15, 20, 0, 0),
				BackgroundColor = Color.FromArgb("#ffffff"),
				Source = "icon_back.png",
				Padding = 10,
				HeightRequest = 50,
				WidthRequest = 50,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			back.Clicked += OnBackClicked;
			

			scanPage = new CameraBarcodeReaderView();
			scanPage.Options = new ZXing.Net.Maui.BarcodeReaderOptions()
			{
				Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
				AutoRotate = true,
				Multiple = false,
			};
            scanPage.BarcodesDetected += ScanPage_BarcodesDetected;
            customOverlay.Children.Add(scanPage);
            customOverlay.Children.Add(back);

            //         this.scanPage = new ZXingScannerPage(customOverlay: customOverlay);
            //scanPage.OnScanResult += (result) => {
            //	scanPage.IsScanning = false;
            //	Device.BeginInvokeOnMainThread(async () => {
            //		await Navigation.PopModalAsync();
            //		companyDetailsViewModel.ScanQrCommand.Execute(result.Text);
            //	});
            //};
            //scanPage.IsScanning = true;
            //await Navigation.PushModalAsync( scanPage);
			//companyDetailsViewModel.ScanQrCommand.Execute("verify_checkin/2/T3djeEhxQm5JdzFPMVdzSnI2allSQT09");
		}

        private void ScanPage_BarcodesDetected(object? sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
			var first = e.Results?.FirstOrDefault();
			if(first is null) return;
			Dispatcher.DispatchAsync(async () =>
			{
				await DisplayAlert("Bardcode", first.Value, "OK");
			}); 
        }

        private void OnBackClicked(object sender, EventArgs e)
		{
            Dispatcher.DispatchAsync(async () =>
            {
                await Navigation.PopModalAsync();
            });
   //         Device.BeginInvokeOnMainThread(async () =>
			//{
			//	//this.scanPage.IsScanning = false;
			//	await Navigation.PopModalAsync();
			//});
		}
    }
}