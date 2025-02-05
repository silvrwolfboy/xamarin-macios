﻿//
// PlatformFramework.cs
//
// Author: Jeffrey Stedfast <jeff@xamarin.com>
//
// Copyright (c) 2016 Xamarin Inc. (www.xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

using Xamarin.Utils;

namespace Xamarin.MacDev.Tasks
{
	public static class PlatformFrameworkHelper
	{
		public static ApplePlatform GetFramework (string targetFrameworkIdentifier)
		{
			switch (targetFrameworkIdentifier) {
			case "Xamarin.Mac":
			case "MonoMac":
				return ApplePlatform.MacOSX;
			case "Xamarin.iOS":
			case "MonoTouch":
				return ApplePlatform.iOS;
			case "Xamarin.WatchOS":
				return ApplePlatform.WatchOS;
			case "Xamarin.TVOS":
				return ApplePlatform.TVOS;
			default:
				throw new InvalidOperationException ("Unknown TargetFrameworkIdentifier: " + targetFrameworkIdentifier);
			}
		}

		public static string GetOperatingSystem (string targetFrameworkIdentifier)
		{
			var framework = PlatformFrameworkHelper.GetFramework (targetFrameworkIdentifier);
			switch (framework) {
			case ApplePlatform.WatchOS:
				return "watchos";
			case ApplePlatform.TVOS:
				return "tvos";
			case ApplePlatform.MacOSX:
				return "osx";
			case ApplePlatform.iOS:
				return "ios";
			default:
				throw new InvalidOperationException (string.Format ("Unknown target framework {0} for target framework identifier {2}.", framework, targetFrameworkIdentifier));
			}
		}
	}
}
