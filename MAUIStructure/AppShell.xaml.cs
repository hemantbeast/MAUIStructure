using MAUIStructure.Helpers;
using MAUIStructure.Pages;

namespace MAUIStructure;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		FlowDirection = Settings.AppLanguage.FlowDirection;

		RegisterPages();
	}

	private void RegisterPages()
	{
		Routing.RegisterRoute(nameof(NewPage), typeof(NewPage));
	}
}

