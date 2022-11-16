using System;

namespace MAUIStructure.Models
{
	public class LanguageModel
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public LanguageEnum Language { get; set; }
		public FlowDirection FlowDirection { get; set; }
	}

	public enum LanguageEnum
	{
		Arabic,
		English
	}
}

