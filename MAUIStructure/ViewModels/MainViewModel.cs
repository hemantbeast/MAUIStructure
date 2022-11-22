using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MAUIStructure.Helpers;
using MAUIStructure.Models;
using MAUIStructure.Pages;
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

		[RelayCommand]
		void ChangeLanguage()
		{
			if (Settings.AppLanguage.Language == LanguageEnum.English) {
				Settings.AppLanguage = App.Languages.FirstOrDefault(x => x.Language == LanguageEnum.Arabic);
			} else {
				Settings.AppLanguage = App.Languages.FirstOrDefault(x => x.Language == LanguageEnum.English);
			}

			App.SetLanguage();
			Application.Current.MainPage = new AppShell();
		}

		[RelayCommand]
		void OpenNextPage()
		{
			Shell.Current.GoToAsync(nameof(NewPage));
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

		public string LanguageButton => Settings.AppLanguage.Language == LanguageEnum.English
			? App.Languages.FirstOrDefault(x => x.Language == LanguageEnum.Arabic).Name
			: App.Languages.FirstOrDefault(x => x.Language == LanguageEnum.English).Name;
	}
}

