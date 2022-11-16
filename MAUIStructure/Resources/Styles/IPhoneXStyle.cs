using System;

namespace MAUIStructure.Resources.Styles
{
	public class IPhoneXStyle : BaseDeviceStyle
	{
		public override string DeviceStyle => "iPhoneX";

		public override GridLength NavigationBarHeight => new GridLength(50);

		public override double ButtonHeight => 45;
	}
}

