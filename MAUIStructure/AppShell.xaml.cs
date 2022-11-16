using MAUIStructure.Helpers;

namespace MAUIStructure;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		FlowDirection = Settings.AppLanguage.FlowDirection;
	}
}

