namespace Terminal.Gui.Xaml.Sample.UI.Views;

public sealed partial class HeaderView : View
{
	public HeaderView()
	{
		DataContext = new HeaderViewModel();
		InitializeComponent();
	}

	private void OnClickMeButtonClicked() =>
		MessageBox.Query("Button Prompt", "Hello, Button.", "OK");

	private void OnNavigateFirstButtonClicked() =>
		((MainWindow)Application.Top).Router.Navigate(new FirstRoutedView());

	private void OnNavigateSecondButtonClicked() =>
		((MainWindow)Application.Top).Router.Navigate(new SecondRoutedView());
}
