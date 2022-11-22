using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using MAUIStructure.Pages;
using MAUIStructure.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MAUIStructure;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMarkup()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddLocalization();

		SetViewModels(builder.Services);
		SetPages(builder.Services);

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	private static void SetViewModels(IServiceCollection services)
	{
		services.AddTransient<MainViewModel>();
	}

	private static void SetPages(IServiceCollection services)
	{
		services.AddTransient<MainPage>();
		services.AddTransient<NewPage>();
	}
}

