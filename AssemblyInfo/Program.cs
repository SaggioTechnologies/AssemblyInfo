using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandLine;
using System.Text.RegularExpressions;

namespace AssemblyInfo
{
	class Program
	{
		static void Main(string[] args)
		{
			var result = CommandLine.Parser.Default.ParseArguments<Options>(args);

			if (result.Errors.Any())
			{
				// error
				return;
			}

			string fullPath = Path.GetFullPath(result.Value.Filename);
			if (!File.Exists(fullPath))
			{
				Console.Error.WriteLine("File does not exist: {0}", result.Value.Filename);
				return;
			}

			Assembly assembly = null;
			try
			{
				assembly = Assembly.LoadFile(fullPath);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine("Could not load .NET assembly: {0}\r\n{1}", result.Value.Filename, ex.Message);
				return;
			}

			Console.WriteLine(result.Value.Template);
			AssemblyInformation info = new AssemblyInformation(assembly);

			string finalString = String.Format(
				result.Value.Template
				.ReplaceCaseInsensitiveFind("$MAJOR", info.Major)
				.ReplaceCaseInsensitiveFind("$MINOR", info.Minor)
				.ReplaceCaseInsensitiveFind("$REVISION", info.Revision)
				.ReplaceCaseInsensitiveFind("$BUILD", info.Build)
				.ReplaceCaseInsensitiveFind("$PRODUCTVERSION", info.ProductVersion)
				.ReplaceCaseInsensitiveFind("$INFORMATIONALVERSION", info.InformationalVersion)
				.ReplaceCaseInsensitiveFind("$FULLNAME", info.FullName)
				);

			finalString = Regex.Unescape(finalString);

			Console.WriteLine(finalString);

		}
	}
}
