using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rvipLection
{
	class Program
	{
		static void Main(string[] args)
		{
			LogicalClock logical = new LogicalClock();
			logical.start();
			Console.ReadKey();
		}
	}
}
