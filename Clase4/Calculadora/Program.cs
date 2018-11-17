using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalc calc = new ProxyCalc();

            int result = calc.Add(2, 3);

            Console.WriteLine(result);
        }
    }

    interface ICalc
    {
        int Add(int a, int b);
        int Substract(int a, int b);
        int Divide(int a, int b);
        int Mult(int a, int b);
    }

    class ProxyCalc : ICalc
    {
        Calc calc = new Calc();

        public int Add(int a, int b)
        {
            return calc.Add(a, b);
        }

        public int Divide(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Mult(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Substract(int a, int b)
        {
            throw new NotImplementedException();
        }
    }

    class Calc : ICalc
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Substract(int a, int b)
        {
            return a - b;
        }
        public int Divide(int a, int b)
        {
            return a / b;
        }
        public int Mult(int a, int b)
        {
            return a * b;
        }
    }
}
