using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Properties
{
	public class Properties
	{
		private Properties()
		{
			_properties = new Dictionary<string, string>();
		}

		public string this[string name]
		{
			get
			{
				if (_properties.ContainsKey(name))
					return _properties[name];
				return string.Empty;
			}
		}

		public static Properties Init()
		{
			var p = new Properties();
			// priority order: app.config, properties file, command line
			var appConfigProperties = new AppConfigReader().Read();
			foreach (var k in appConfigProperties)
				p._properties[k.Key] = k.Value;
			var fileProperties = new PropertiesFileReader().Read();
			foreach (var k in fileProperties)
				p._properties[k.Key] = k.Value;
			var cmdProperties = new CommandLineReader().Read();
			foreach (var k in cmdProperties)
				p._properties[k.Key] = k.Value;
			return p;
		}

		private IDictionary<string, string> _properties;
	}
}
