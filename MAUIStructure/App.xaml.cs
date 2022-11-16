using System.Globalization;
using MAUIStructure.Helpers;
using MAUIStructure.Models;
using MAUIStructure.Resources.Strings;
using MAUIStructure.Resources.Styles;

namespace MAUIStructure;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		SetCurrentResources();
		SetLanguage();
		MainPage = new AppShell();
	}

	private void SetCurrentResources()
	{
		var height = DeviceDisplay.Current.MainDisplayInfo.Height / DeviceDisplay.Current.MainDisplayInfo.Density;

		if (DeviceInfo.Platform == DevicePlatform.iOS && height > 800) {
			dictionary.MergedDictionaries.Add(new IPhoneXStyle());
		} else {
			dictionary.MergedDictionaries.Add(new DefaultStyle());
		}
	}

	public static void SetLanguage()
	{
		if (Settings.AppLanguage == null) {
			Settings.AppLanguage = Languages.FirstOrDefault();
		}

		var culture = new CultureInfo(Settings.AppLanguage.Code);
		Thread.CurrentThread.CurrentCulture = culture;
		Thread.CurrentThread.CurrentUICulture = culture;
		CultureInfo.DefaultThreadCurrentCulture = culture;
		CultureInfo.DefaultThreadCurrentUICulture = culture;
		LocalizationResources.Culture = culture;
	}

	public static List<LanguageModel> Languages => new List<LanguageModel>() {
		new LanguageModel() {
			Name = "English",
			Code = "en",
			Language = LanguageEnum.English,
			FlowDirection = FlowDirection.LeftToRight
		},
		new LanguageModel() {
			Name = "العربية",
			Code = "ar",
			Language = LanguageEnum.Arabic,
			FlowDirection = FlowDirection.RightToLeft
		},
	};
}

