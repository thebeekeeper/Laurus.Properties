﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Properties.Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = Properties.Init();
			var test = p["test"];
		}
	}
}
