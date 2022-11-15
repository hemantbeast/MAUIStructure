using System;
using MAUIStructure.ViewModels;

namespace MAUIStructure.Pages
{
	public class BaseContentPage : ContentPage
	{
		BaseViewModel _baseViewModel;
		bool _isFirstTime;

		public BaseContentPage()
		{
			_isFirstTime = true;
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			_baseViewModel = (BaseViewModel)BindingContext;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (_isFirstTime) {
				_isFirstTime = false;
				_baseViewModel?.OnFirstTimeAppearing();
			} else {
				_baseViewModel?.OnAppearing();
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_baseViewModel?.OnDisappearing();
		}
	}
}

