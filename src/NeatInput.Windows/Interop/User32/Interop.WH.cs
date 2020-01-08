// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file for more information:
//      https://github.com/dotnet/winforms/blob/master/LICENSE.TXT

internal static partial class Interop
{
    internal static partial class User32
    {
        internal enum WH : int
        {
            KEYBOARD_LL = 13,
            MOUSE_LL = 14
        }
    }
}