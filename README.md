<h1 align="center">NeatInput</h1>
<div align="center">

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-grammas-recipe.svg)](https://forthebadge.com)

[![GitHub license](https://img.shields.io/github/license/LegendaryB/NeatInput.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/NeatInput/blob/master/LICENSE.md)
[![Nuget](https://img.shields.io/nuget/v/NeatInput.svg?style=flat-square)](https://www.nuget.org/packages/NeatInput/)
[![Donate](https://img.shields.io/badge/Donate-PayPal-blue.svg)](https://paypal.me/alphadaniel)

Useful and clean .NET Standard library to monitor keyboard and mouse input on Windows.

<sub>Built with ❤︎ by Daniel Belz</sub>
</div><br>

## Getting started

### Monitoring mouse and keyboard input
To monitor mouse and keyboard input you need to attach to the OnInputReceived event handler:

```csharp
private static void Main()
{
    var inputProvider = new InputProvider();
    inputProvider.InputReceived += OnInputReceived;

    Console.ReadLine();
}

private void OnInputReceived(Input input)
{
    Console.WriteLine($"Key: {input.Key} | State: {input.State}");
}
```

### Monitoring mouse input
To monitor mouse input you need to attach to the OnMouseInputReceived event handler:

```csharp
private static void Main()
{
    var inputProvider = new InputProvider();
    inputProvider.MouseInputReceived += OnMouseInputReceived;

    Console.ReadLine();
}

private void OnMouseInputReceived(MouseInput input)
{
    Console.WriteLine($"Key: {input.Key} | State: {input.State} | X: {input.X} | Y: {input.Y}");
}
```

### Monitoring keyboard input
To monitor keyboard input you need to attach to the OnKeyboardInputReceived event handler:

```csharp
private static void Main()
{
    var inputProvider = new InputProvider();
    inputProvider.KeyboardInputReceived += OnKeyboardInputReceived;

    Console.ReadLine();
}

private void OnKeyboardInputReceived(KeyboardInput input)
{
    Console.WriteLine($"Key: {input.Key} | State: {input.State}");
}
```

## Contributing

__Contributions are always welcome!__  
Just send me a pull request and I will look at it. If you have more changes please create a issue to discuss it first.

## Donate
If you like my software, please consider [supporting me](https://paypal.me/alphadaniel) with a little donation. Thank you for your support! You are great!

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
