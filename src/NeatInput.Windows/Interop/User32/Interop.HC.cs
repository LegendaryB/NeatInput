// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file for more information:
//      https://github.com/dotnet/winforms/blob/master/LICENSE.TXT

internal static partial class Interop
{
    internal static partial class User32
    {
        internal enum HC : int
        {
            ACTION = 0,
            GETNEXT = 1,
            SKIP = 2,
            NOREMOVE = 3,
            NOREM = NOREMOVE,
            SYSMODALON = 4,
            SYSMODALOFF = 5,
        }
    }
}
