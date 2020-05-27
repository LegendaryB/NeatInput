// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file for more information:
//      https://github.com/dotnet/winforms/blob/master/LICENSE.TXT

using System;

internal static partial class Interop
{
    internal static partial class User32
    {
        [Flags]
        internal enum PM : uint
        {
            NOREMOVE = 0x0000,
            REMOVE = 0x0001,
            NOYIELD = 0x0002
        }
    }
}
