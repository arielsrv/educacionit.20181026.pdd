using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiColeccion
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection myCollection = new MyCollection();
            myCollection.Add(123);
            myCollection.Add(124);
            myCollection.Add(125);

            myCollection.Sort(new QuickSort());
        }
    }

    class MyCollection
    {
        private List<int> values = new List<int>();

        public void Add(int value)
        {
            this.values.Add(value);
        }

        public void Sort(BaseSort baseSort)
        {
            baseSort.Sort(values);
        }
    }

    abstract class BaseSort
    {
        public abstract void Sort(List<int> values);
    }

    class BubbleSort : BaseSort
    {
        public override void Sort(List<int> values)
        {
            // TODO: hacer bubble sort
        }
    }

    class QuickSort : BaseSort
    {
        public override void Sort(List<int> values)
        {
            values.Sort();
        }
    }
}
