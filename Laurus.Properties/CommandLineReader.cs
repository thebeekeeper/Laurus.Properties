using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Properties
{
	public class CommandLineReader : IPropertyReader
	{
		public IDictionary<string, string> Read()
		{
			var args = Environment.GetCommandLineArgs().Where(a => a.StartsWith("-D"));
			var d = new Dictionary<string, string>();
			foreach (var a in args)
			{
				var kvp = a.Split('=');
				d.Add(kvp[0], kvp[1]);
			}
			return d;
		}
	}
}
