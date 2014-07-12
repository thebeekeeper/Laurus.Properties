using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Properties
{
	public interface IPropertyReader
	{
		IDictionary<string, string> Read();
	}
}
