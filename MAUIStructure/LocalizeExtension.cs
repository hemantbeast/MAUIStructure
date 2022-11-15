using System;
using MAUIStructure.Resources.Strings;
using Microsoft.Extensions.Localization;

namespace MAUIStructure
{
	[ContentProperty(nameof(Key))]
	public class LocalizeExtension : IMarkupExtension
	{
		readonly IStringLocalizer<LocalizationResources> _localizer;

		public string Key { get; set; } = string.Empty;

		public LocalizeExtension()
		{
			_localizer = ServiceHelper.GetService<IStringLocalizer<LocalizationResources>>();
		}

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			string localizedText = _localizer[Key];
			return localizedText;
		}

		object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
	}
}

