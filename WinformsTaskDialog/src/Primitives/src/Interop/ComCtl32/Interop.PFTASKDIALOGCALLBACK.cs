﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class ComCtl32
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate HRESULT PFTASKDIALOGCALLBACK(
            IntPtr hwnd,
            TDN msg,
            IntPtr wParam,
            IntPtr lParam,
            IntPtr lpRefData);
    }
}
