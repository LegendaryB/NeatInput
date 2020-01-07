<h1 align="center">NeatInput</h1>
<div align="center">

[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-grammas-recipe.svg)](https://forthebadge.com)

[![GitHub license](https://img.shields.io/github/license/LegendaryB/NeatInput.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/NeatInput/blob/master/LICENSE.md)
[![Nuget](https://img.shields.io/nuget/v/NeatInput.Windows.svg?style=flat-square)](https://www.nuget.org/packages/NeatInput.Windows/)
[![GitHub last commit](https://img.shields.io/github/last-commit/LegendaryB/NeatInput.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/NeatInput)
[![GitHub issues](https://img.shields.io/github/issues/LegendaryB/NeatInput.svg?longCache=true&style=flat-square)](https://github.com/LegendaryB/NeatInput/issues)

A .NET standard project which aims to make keyboard and mouse input monitoring easy on Windows and Linux.

<sub>Built with ❤︎ by Daniel Belz</sub>
</div><br>

## Important
* Currently only windows is supported.

### Switching from version < 2
This is version 2.0 of the library. I decided to increase the version of the library directly from 1.0.4 to 2 because these changes mean breaking changes. The old NeatInput NuGet package is from now on obsolete and not supported anymore.

The entire API of the library has changed so you need to make some adjustments when upgrading to 2. 

## How it works

### Windows
The mouse and keyboard hook are set using [SetWindowsHook](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowshookexa). When using the Listen method of the InputSource class a thread is created which is used to receive the messages / events. After the hooks are set a custom message loop is started which receives windows messages.

### Linux
Currently linux is not supported. This section will follow when the project has a implementation.

## Documentation
The documentation can be found in the [wiki](https://github.com/LegendaryB/NeatInput/wiki).

## Contributing

__Contributions are always welcome!__  
Just send me a pull request and I will look at it. If you have more changes please create a issue to discuss it first.

## Donate
If you like my software, please consider [supporting me](https://paypal.me/alphadaniel) with a little donation. Thank you for your support! You are great!

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
