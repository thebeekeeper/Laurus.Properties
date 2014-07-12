using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Properties
{
	public class PropertiesFileReader : IPropertyReader
	{
		public IDictionary<string, string> Read()
		{
			var content = GetPropertiesFile();
			var lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			var values = from l in lines
						 where !l.StartsWith("#")
						 where !l.StartsWith("!")
						 select new KeyValuePair<string, string>(l.Substring(0, l.IndexOf("=")), l.Substring(l.IndexOf('=') + 1));
			var d = new Dictionary<string, string>();
            foreach(var x in values)
			{
				d.Add(x.Key, x.Value);
			}
			return d;
		}

        private string GetPropertiesFile()
		{
			var f = Directory.GetFiles(Environment.CurrentDirectory).FirstOrDefault(n => n.EndsWith(".properties"));
			if (f != string.Empty)
				return File.ReadAllText(f);
			return string.Empty;
		}
	}
}
