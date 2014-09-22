using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AssemblyInfo
{
	static class Extensions
	{
		public static string CaseInsenstiveReplace(this string originalString, string oldValue, string newValue)
		{
			Regex regEx = new Regex(oldValue, RegexOptions.IgnoreCase | RegexOptions.Multiline);
			return regEx.Replace(originalString, newValue);
		}

		public static string ReplaceCaseInsensitiveFind(this string str, string findMe, string newValue)
		{
			return Regex.Replace(str,
				Regex.Escape(findMe),
				Regex.Replace(newValue, "\\$[0-9]+", @"$$$0"),
				RegexOptions.IgnoreCase);
		}
	}
}
