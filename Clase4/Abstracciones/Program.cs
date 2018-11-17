using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    abstract class Abstract
    {
        protected Impl impl;

        public Abstract(Impl impl)
        {
            this.impl = impl;
        }

        public abstract void Operation();
    }

    class Abstract1 : Abstract
    {
        public Abstract1(Impl impl) : base(impl)
        {
        }

        public override void Operation()
        {
            this.impl.Execute();   
        }
    }

    class Abstract2 : Abstract
    {
        public Abstract2(Impl impl) : base(impl)
        {
        }

        public override void Operation()
        {
            this.impl.Execute();
        }
    }

    abstract class Impl 
    {
        public abstract void Execute();
    }

    class Impl1 : Impl
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    class Impl2 : Impl
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
