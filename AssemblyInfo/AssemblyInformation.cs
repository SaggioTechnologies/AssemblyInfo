using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AssemblyInfo
{
	internal class AssemblyInformation
	{
		Assembly _assembly;

		internal string InformationalVersion { get; set; }
		internal string ProductVersion { get; set; }
		internal string Major { get; set; }
		internal string Minor { get; set; }
		internal string Revision { get; set; }
		internal string Build { get; set; }
		internal string FullName { get; set; }

		internal AssemblyInformation(Assembly assembly)
		{
			_assembly = assembly;

			this.InformationalVersion = string.Empty;
			this.ProductVersion = string.Empty;
			this.Major = string.Empty;
			this.Minor = string.Empty;
			this.Revision = string.Empty;
			this.Build = string.Empty;
			this.FullName = string.Empty;

			try
			{
				AssemblyInformationalVersionAttribute attribute = (AssemblyInformationalVersionAttribute)_assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false).FirstOrDefault();

				if (attribute != null)
				{
					this.InformationalVersion = attribute.InformationalVersion;
				}
			}
			catch { }

			try
			{
				this.ProductVersion = FileVersionInfo.GetVersionInfo(_assembly.Location).ProductVersion;
			}
			catch { }

			try
			{
				this.FullName = _assembly.FullName;
			}
			catch { }

			try
			{
				this.Major = _assembly.GetName().Version.Major.ToString();
			}
			catch { }

			try
			{
				this.Minor = _assembly.GetName().Version.Minor.ToString();
			}
			catch { }

			try
			{
				this.Revision = _assembly.GetName().Version.Revision.ToString();
			}
			catch { }

			try
			{
				this.Build = _assembly.GetName().Version.Build.ToString();
			}
			catch { }
		}

	}
}
