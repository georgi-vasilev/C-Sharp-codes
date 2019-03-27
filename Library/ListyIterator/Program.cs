using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> create = Console.ReadLine().Split(' ').ToList();
			create.RemoveAt(0);
			ListyIterator<string> input = new ListyIterator<string>(create);
			string command = Console.ReadLine();
			while (command!="END")
			{
				command = Console.ReadLine();
				switch (command)
				{
					case "Move":
						{
							Console.WriteLine(input.Move());
						}
						break;
					case "HasNext":
						{
							Console.WriteLine(input.HasNext());
						}
						break;
					case "Print":
						{
							input.Print();
						}
						break;
					case "PrintAll":
						{
							input.PrintAll();
						}
						break;
				}
			}
		}
	}
}
