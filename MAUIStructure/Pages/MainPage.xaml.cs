using MAUIStructure.ViewModels;

namespace MAUIStructure.Pages;

public partial class MainPage : BaseContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
