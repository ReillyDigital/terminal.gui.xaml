# ReillyDigital.Terminal.Gui.Xaml

A XAML preprocessor for the Terminal.Gui toolkit for building rich console apps for .NET that works on Windows, Mac, and Linux/Unix.

This library will process XAML sources to generate C# partial class definitions for classes that extend a Terminal.Gui View, allowing for a XAML View definition with a C# code-behind for additional logic.

## Usage

Create a XAML View named like `MyWindow.xaml`:
```xml
<Window
	xmlns="https://github.com/gui-cs"
	xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
	x:Class="MyWindow"
	x:DataType="MyWindowModel"
	Height="{TemplateBinding Dim.Fill()}"
	Title="XAML Example"
	Width="{TemplateBinding Dim.Fill()}"
>
	<Label Text="{Binding Greeting}" X="{TemplateBinding Pos.Center()}" />
	<Button
		Clicked="{TemplateEventBinding OnClickMeButtonClicked}"
		Text="Click Me!"
		X="{TemplateBinding Pos.Center()}"
	/>
	<MyView
		Height="{TemplateBinding Dim.Percent(10)}"
		Width="{TemplateBinding Dim.Fill()}"
	/>
</Window>
```

Create a C# code-behind file named like `MyWindow.xaml.cs`:
```csharp
public partial class MyWindow : Window
{
	private string Greeting { get; } = "Hello, World.";

	public MyWindow() : base()
	{
		DataContext = new MyWindowModel();
		InitializeComponent();
	}

	private void OnClickMeButtonClicked() =>
		MessageBox.Query("Button Prompt", "Hello, Button.", "OK");
}
```

Create a C# model file named like `MyWindowModel.cs`:
```csharp
public class MyWindowModel
{
	public string Greeting { get; } = "Hello, World.";
}
```

Create a XAML View file named like `MyView.xaml`:
```xml
<UserControl xmlns="https://github.com/gui-cs">
	<Label Text="Content from MyView!" />
</UserControl>
```

Create a C# code-behind file named like `MyView.xaml.cs`:
```csharp
public partial class MyView : View
{
	public MyView() : base() => InitializeComponent();
}
```

## Notes

This library targets the Terminal.Gui 1.X version.

## Links

Sample Project:
https://gitlab.com/reilly-digital/terminal.gui.xaml/-/tree/main/src/Terminal.Gui.Xaml.Sample

NuGet:
https://www.nuget.org/packages/ReillyDigital.Terminal.Gui.Xaml

Terminal.Gui - Git:
https://github.com/gui-cs/Terminal.Gui

Terminal.Gui - NuGet:
https://www.nuget.org/packages/Terminal.Gui
