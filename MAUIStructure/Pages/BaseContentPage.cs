using System;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using MAUIStructure.ViewModels;

namespace MAUIStructure.Pages
{
	public class BaseContentPage : ContentPage
	{
		BaseViewModel _baseViewModel;
		bool _isFirstTime;

		public static readonly BindableProperty StatusBarColorProperty =
			BindableProperty.Create(nameof(StatusBarColor), typeof(Color), typeof(BaseContentPage), Colors.White,
				propertyChanged: (bindable, oldValue, newValue) => ((BaseContentPage)bindable).UpdateStatusBarColor());

		public static readonly BindableProperty StatusBarStyleProperty =
			BindableProperty.Create(nameof(StatusBarStyle), typeof(StatusBarStyle), typeof(BaseContentPage), StatusBarStyle.DarkContent,
				propertyChanged: (bindable, oldValue, newValue) => ((BaseContentPage)bindable).UpdateStatusBarColor());

		public Color StatusBarColor
		{
			get => (Color)GetValue(StatusBarColorProperty);
			set => SetValue(StatusBarColorProperty, value);
		}

		public StatusBarStyle StatusBarStyle
		{
			get => (StatusBarStyle)GetValue(StatusBarStyleProperty);
			set => SetValue(StatusBarStyleProperty, value);
		}

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

		private void UpdateStatusBarColor()
		{
			if (Behaviors.Any(x => x.GetType() == typeof(StatusBarBehavior))) {
				var statusBarBehavior = Behaviors.FirstOrDefault(x => x.GetType() == typeof(StatusBarBehavior)) as StatusBarBehavior;
				statusBarBehavior.StatusBarColor = StatusBarColor;
				statusBarBehavior.StatusBarStyle = StatusBarStyle;
			} else {
				Behaviors.Add(new StatusBarBehavior {
					StatusBarColor = StatusBarColor,
					StatusBarStyle = StatusBarStyle
				});
			}
		}
	}
}

