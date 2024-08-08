namespace Terminal.Gui.Xaml.Sample.UI.Windows;

public sealed partial class MainWindow : Window
{
	public MainWindow()
	{
		DataContext = new MainWindowModel();
		InitializeComponent();
	}
}
