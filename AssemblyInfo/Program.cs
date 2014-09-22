using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandLine;

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
			Console.WriteLine(
				result.Value.Template
				.ReplaceCaseInsensitiveFind("$MAJOR", info.Major)
				.ReplaceCaseInsensitiveFind("$MINOR", info.Minor)
				.ReplaceCaseInsensitiveFind("$REVISION", info.Revision)
				.ReplaceCaseInsensitiveFind("$BUILD", info.Build)
				.ReplaceCaseInsensitiveFind("$PRODUCTVERSION", info.ProductVersion)
				.ReplaceCaseInsensitiveFind("$INFORMATIONALVERSION", info.InformationalVersion)
				.ReplaceCaseInsensitiveFind("$FULLNAME", info.FullName)
				);

		}

		//http://blogs.msdn.com/b/microsoft_press/archive/2010/02/03/jeffrey-richter-excerpt-2-from-clr-via-c-third-edition.aspx
		static void ActivateAssemblyResolver()
		{
			AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
			{
				String resourceName = "AssemblyLoadingAndReflection." + new AssemblyName(args.Name).Name + ".dll";

				using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
				{
					Byte[] assemblyData = new Byte[stream.Length];
					stream.Read(assemblyData, 0, assemblyData.Length);
					return Assembly.Load(assemblyData);
				}
			};
		}
	}
}
