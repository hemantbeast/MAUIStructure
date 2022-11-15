using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MAUIStructure.Views;

public partial class NavigationView : Grid
{
	public static readonly BindableProperty LeftImageProperty =
		BindableProperty.Create(nameof(LeftImage), typeof(string), typeof(NavigationView), "ic_back");

	public static readonly BindableProperty LeftCommandProperty =
		BindableProperty.Create(nameof(LeftCommand), typeof(ICommand), typeof(NavigationView), null);

	public static readonly BindableProperty TitleProperty =
		BindableProperty.Create(nameof(Title), typeof(string), typeof(NavigationView), string.Empty);

	public static readonly BindableProperty RightImageProperty =
		BindableProperty.Create(nameof(RightImage), typeof(string), typeof(NavigationView), string.Empty);

	public static readonly BindableProperty RightCommandProperty =
		BindableProperty.Create(nameof(RightCommand), typeof(ICommand), typeof(NavigationView), null);

	public static readonly BindableProperty FontSizeProperty =
		BindableProperty.Create(nameof(FontSize), typeof(double), typeof(NavigationView), 16d);

	public string LeftImage {
		get => (string)GetValue(LeftImageProperty);
		set => SetValue(LeftImageProperty, value);
	}

	public ICommand LeftCommand {
		get => (ICommand)GetValue(LeftCommandProperty);
		set => SetValue(LeftCommandProperty, value);
	}

	public string Title {
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	public string RightImage {
		get => (string)GetValue(RightImageProperty);
		set => SetValue(RightImageProperty, value);
	}

	public ICommand RightCommand {
		get => (ICommand)GetValue(RightCommandProperty);
		set => SetValue(RightCommandProperty, value);
	}

	public double FontSize {
		get => (double)GetValue(FontSizeProperty);
		set => SetValue(FontSizeProperty, value);
	}

	public NavigationView()
	{
		InitializeComponent();
		SetBackButtonPressed();
	}

	protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		base.OnPropertyChanged(propertyName);

		if (propertyName.Equals(LeftImageProperty.PropertyName)) {
			SetBackButtonPressed();
		}
	}

	void SetBackButtonPressed()
	{
		LeftCommand = new Command(async () => {
			try {
				if (LeftImage.StartsWith("ic_back", StringComparison.OrdinalIgnoreCase)) {
					await Shell.Current.GoToAsync("..", true);
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		});
	}
}
