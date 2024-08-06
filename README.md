# ReillyDigital.Terminal.Gui.Xaml

A XAML preprocessor for the Terminal.Gui toolkit for building rich console apps for .NET that works on Windows, Mac, and Linux/Unix.

This library will process XAML sources to generate C# partial class definitions for classes that extend a Terminal.Gui View, allowing for a XAML View definition with a C# code-behind for additional logic.

## Usage

Create a XAML View named like MyWindow.xaml.cs:
```xml
<Window
	xmlns="https://gitlab.com/reilly-digital"
	Title="XAML Example"
	Height="{TemplateBinding Dim.Fill()}"
	Width="{TemplateBinding Dim.Fill()}"
>
    <Label Text="{TemplateBinding Greeting}" X="{TemplateBinding Pos.Center()}" />
	<Button
	    Text="Click Me!"
	    Clicked="{TemplateEventBinding Button_Clicked}"
	    X="{TemplateBinding Pos.Center()}
    />
	<MyView Height="{TemplateBinding Dim.Percent(10)}" Width="{TemplateBinding Dim.Fill()}" />
</Window>
```

Create a C# code-behind named like MyWindow.cs:
```csharp
public partial class MyWindow : Window
{
    private string Greeting { get; } = "Hello, World.";

    public MyWindow() : base() => InitializeComponent();

    private void Button_Clicked() => MessageBox.Query("Button Prompt", "Hello, Button.", "OK");
}
```

Create a XAML View named like MyView.xaml.cs:
```xml
<UserControl xmlns="https://gitlab.com/reilly-digital">
    <Label Text="Content from MyView!" />
</UserControl>
```

Create a C# code-behind named like MyView.cs:
```csharp
public partial class MyView : View
{
    public MyView() : base() => InitializeComponent();
}
```

## Notes

This library targets the Terminal.Gui 1.X version.

## Links

NuGet:
https://www.nuget.org/packages/ReillyDigital.Terminal.Gui.Xaml

Terminal.Gui - Git:
https://github.com/gui-cs/Terminal.Gui

Terminal.Gui - NuGet:
https://www.nuget.org/packages/Terminal.Gui
