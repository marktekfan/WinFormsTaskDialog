﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

internal static partial class Interop
{
    internal static partial class Oleaut32
    {
        public unsafe struct DISPPARAMS
        {
            //BP public VARIANT* rgvarg;
            public IntPtr rgvarg;
            public Ole32.DispatchID* rgdispidNamedArgs;
            public uint cArgs;
            public uint cNamedArgs;
        }
    }
}
