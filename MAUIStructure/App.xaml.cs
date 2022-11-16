using System.Globalization;
using MAUIStructure.Helpers;
using MAUIStructure.Models;
using MAUIStructure.Resources.Strings;

namespace MAUIStructure;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		SetLanguage();
		MainPage = new AppShell();
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

