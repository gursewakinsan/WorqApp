﻿using WorqApp.ViewModels;

namespace WorqApp.Views.Apartment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotStartedDetailsPage : ContentPage
    {
        NotStartedDetailsPageViewModel viewModel;
        public NotStartedDetailsPage(Models.ApartmentCommunityTicketModel apartment)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewModel = new NotStartedDetailsPageViewModel(this.Navigation);
			viewModel.SelectedApartmentCommunityTicket = apartment;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.ApartmentCommunityTicketDetailCommand.Execute(null);
		}
	}
}