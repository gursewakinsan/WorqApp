﻿using WorqApp.ViewModels;

namespace WorqApp.Views.Queue
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OperatorQueueDetailPage : ContentPage
	{
		OperatorQueueDetailPageViewModel viewModel;
		public OperatorQueueDetailPage()
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			BindingContext = viewModel = new OperatorQueueDetailPageViewModel(this.Navigation);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.OperatorQueueWaitingCountCommand.Execute(null);
		}
	}
}