﻿using WorqApp.ViewModels;

namespace WorqApp.Views.MarketPlace
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfessionalTodoUpdatePage : ContentPage
    {
        ProfessionalTodoUpdatePageViewModel ViewModel;
        public ProfessionalTodoUpdatePage(Models.CompanyMarketplaceListResponse model)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = ViewModel = new ProfessionalTodoUpdatePageViewModel(this.Navigation);
            Helper.Helper.DomainId = model.Id;
            ViewModel.SelectedCompanyMarketplace = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.ProfessionalTodoUpdateCommand.Execute(null);
        }

        void OnGridTapped(System.Object sender, System.EventArgs e)
        {
            Grid control = sender as Grid;
            OnItemTapped(control.BindingContext as Models.ProfessionalTodoUpdateModel);
        }

        void OnLabelTapped(System.Object sender, System.EventArgs e)
        {
            Label control = sender as Label;
            OnItemTapped(control.BindingContext as Models.ProfessionalTodoUpdateModel);
        }

        private void OnButtonTapped(object sender, System.EventArgs e)
        {
            Button control = sender as Button;
            OnItemTapped(control.BindingContext as Models.ProfessionalTodoUpdateModel);
        }

        async void OnItemTapped(Models.ProfessionalTodoUpdateModel model)
        {
            if (model.Name.Equals("Services") || model.Name.Equals("Pricing"))
                await Navigation.PushAsync(new CompanyMarketplaceServiceDetailPage());
            else if (model.Name.Equals("Area"))
                await Navigation.PushAsync(new AreaDetailPage());
            else if (model.Name.Equals("Languages"))
                await Navigation.PushAsync(new SuportedLanguagesListPage());
        }
    }
}