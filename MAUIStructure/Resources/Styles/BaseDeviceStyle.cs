using System;

namespace MAUIStructure.Resources.Styles
{
	public abstract class BaseDeviceStyle : ResourceDictionary
	{
		public BaseDeviceStyle()
		{
			Add(nameof(DeviceStyle), DeviceStyle);
			Add(nameof(NavigationBarHeight), NavigationBarHeight);
			Add(nameof(ButtonHeight), ButtonHeight);
		}

		public abstract string DeviceStyle { get; }

		public abstract GridLength NavigationBarHeight { get; }

		public abstract double ButtonHeight { get; }
	}
}

