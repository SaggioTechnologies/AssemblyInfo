using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyInfo
{
	internal class Options
	{
		[Value(0, Required = true)]
		public string Filename { get; set; }

		[Option('t', "template", Required = true, HelpText = "Specify template for output.")]
		public string Template { get; set; }
	}
}
