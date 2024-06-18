﻿using WorqApp.ViewModels;

namespace WorqApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChildrenMissingDetailsPage : ContentPage
	{
		Models.Children childrenDetails;
		ChildrenMissingDetailsViewModel childrenMissingDetailsViewModel;
		public ChildrenMissingDetailsPage(Models.Children children)
		{
			InitializeComponent();
			NavigationPage.SetBackButtonTitle(this, "");
			childrenDetails = children;
			BindingContext = new ChildrenMissingDetailsViewModel(this.Navigation);
		}

		protected override void OnBindingContextChanged()
		{
			childrenMissingDetailsViewModel = BindingContext as ChildrenMissingDetailsViewModel;
			childrenMissingDetailsViewModel.ChildrenDetails = childrenDetails;
			base.OnBindingContextChanged();
		}
	}
}