using System;

namespace MAUIStructure.Resources.Styles
{
	public class DefaultStyle : BaseDeviceStyle
	{
		public override string DeviceStyle => "Default";

		public override GridLength NavigationBarHeight => new GridLength(DeviceInfo.Platform == DevicePlatform.iOS ? 44 : 50);

		public override double ButtonHeight => DeviceInfo.Idiom == DeviceIdiom.Phone ? 40 : 50;
	}
}

