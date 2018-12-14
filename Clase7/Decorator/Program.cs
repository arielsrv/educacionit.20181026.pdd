using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoracion
{
    class Program
    {
        //@Cache
        //@Auth
        //@MyLogic
        static void Main(string[] args)
        {
            BaseElement element = new ElementDecorator(new MyLogic(new Element()));
            element.Do();
        }
    }

    abstract class BaseElement
    {
        public abstract void Do();
    }

    class ElementDecorator : BaseElement
    {
        BaseElement baseElement;

        public ElementDecorator(BaseElement baseElement)
        {
            this.baseElement = baseElement;
        }

        public override void Do()
        {
            throw new NotImplementedException();
        }
    }

    class MyLogic : ElementDecorator
    {
        public MyLogic(BaseElement baseElement) : base(baseElement)
        {
        }
    }

    class Element : BaseElement
    {
        public override void Do()
        {
            throw new NotImplementedException();
        }
    }
}