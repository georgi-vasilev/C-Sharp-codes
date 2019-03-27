using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator
{
	class ListyIterator<T>:IEnumerable<T>
	{
		public List<T> elements { get; set; }
		private int currentIndex;
		private int nextIndex;
		public ListyIterator(List<T> elements)
		{
			this.elements = elements;
			this.currentIndex = 0;
		}
		public bool Move()
		{
			if(this.elements.Count-1>this.currentIndex)
			{
				this.currentIndex++;
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool HasNext()
		{
			if(this.currentIndex==this.elements.Count-1)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public void Print()
		{
			if(this.elements.Count==0)
			{
				Console.WriteLine("Invalid Operation!");
			}
			else
			{
				Console.WriteLine(this.elements[currentIndex]);
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < this.elements.Count; i++)
			{
				yield return this.elements[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
		public void PrintAll()
		{
			foreach (var element in elements)
			{
				Console.Write(element.ToString() + " ");
			}
			Console.WriteLine();
		}
	}
}
