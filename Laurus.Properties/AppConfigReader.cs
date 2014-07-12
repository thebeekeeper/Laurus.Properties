using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Properties
{
	public class AppConfigReader : IPropertyReader
	{
		public IDictionary<string, string> Read()
		{
			var values = new Dictionary<string, string>();
            for(int i = 0 ; i < ConfigurationManager.AppSettings.Count ; i++)
			{
                var key = ConfigurationManager.AppSettings.GetKey(i);
                var value = ConfigurationManager.AppSettings[key];
				values.Add(key, value);
			}
			return values;
		}
	}
}
