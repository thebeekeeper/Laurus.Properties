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

        public static Properties Init(string[] args)
		{
			var p = new Properties();
            // priority order: app.config, properties file, command line
			var appConfigProperties = new AppConfigReader().Read();
			foreach (var k in appConfigProperties)
				p._properties.Add(k);
			var fileProperties = new PropertiesFileReader().Read();
			foreach (var k in fileProperties)
				p._properties.Add(k);
			var cmdProperties = new CommandLineReader().Read();
			foreach (var k in cmdProperties)
				p._properties.Add(k);
            return p;
		}

		private IDictionary<string, string> _properties;
    }
}
