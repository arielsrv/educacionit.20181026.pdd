using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composicion
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Component
    {

    }

    class Simple : Component
    {

    }

    class Composite : Component
    {
        List<Component> components = new List<Component>();
    }
}
