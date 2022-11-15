using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUIStructure.ViewModels
{
	[ObservableObject]
	public partial class BaseViewModel
	{
		public BaseViewModel()
		{
		}

		public virtual void OnFirstTimeAppearing() { }

		public virtual void OnAppearing() { }

		public virtual void OnDisappearing() {
			IsRefreshing = false;
		}

		[ObservableProperty]
		public bool isRefreshing;
	}
}

