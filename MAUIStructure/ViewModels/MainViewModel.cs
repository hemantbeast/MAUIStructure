using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIStructure.Resources.Strings;

namespace MAUIStructure.ViewModels
{
	public partial class MainViewModel : BaseViewModel
	{
		public MainViewModel()
		{
		}

		[RelayCommand]
		void IncrementCount()
		{
			Count++;
		}

		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(ButtonText))]
		int count;

		public string ButtonText {
			get {
				if (Count == 0) {
					return LocalizationResources.clickMe;
				} else {
					return Count == 1 ? $"Clicked {Count} time" : $"Clicked {Count} times";
				}
			}
		}
	}
}

