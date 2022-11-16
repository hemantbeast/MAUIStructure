using System;
using MAUIStructure.Models;
using Newtonsoft.Json;

namespace MAUIStructure.Helpers
{
	public static class Settings
	{
		const string AppLanguageKey = "AppLanguageKey";
		static readonly string AppLanguageDefault = string.Empty;

		public static LanguageModel AppLanguage {
			get {
				var appLanguage = Preferences.Get(AppLanguageKey, AppLanguageDefault);
				return appLanguage != null ? JsonConvert.DeserializeObject<LanguageModel>(appLanguage) : null;
			}
			set {
				var appLanguage = JsonConvert.SerializeObject(value);
				Preferences.Set(AppLanguageKey, appLanguage);
			}
		}
	}
}

