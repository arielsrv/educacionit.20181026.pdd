using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiedraPapelTijera
{
    class Program
    {
        static void Main(string[] args)
        {
            Choice c1 = new Rock();
            Choice c2 = new Paper();

            Console.WriteLine(c1.LoseAgainst(c2));
        }
    }

    abstract class Choice
    {
        public abstract bool LoseAgainst(Paper paper);
        public abstract bool LoseAgainst(Scissors scissors);
        public abstract bool LoseAgainst(Rock rock);

        public abstract bool LoseAgainst(Choice choice);
    }

    class Paper : Choice
    {
        public override bool LoseAgainst(Paper paper)
        {
            return false;
        }

        public override bool LoseAgainst(Scissors scissors)
        {
            return true;
        }

        public override bool LoseAgainst(Rock rock)
        {
            return true;
        }

        public override bool LoseAgainst(Choice choice)
        {
            return choice.LoseAgainst(this);
        }
    }

    class Scissors : Choice
    {
        public override bool LoseAgainst(Paper paper)
        {
            return false;
        }

        public override bool LoseAgainst(Scissors scissors)
        {
            return false;
        }

        public override bool LoseAgainst(Rock rock)
        {
            return true;
        }

        public override bool LoseAgainst(Choice choice)
        {
            return choice.LoseAgainst(this);
        }
    }

    class Rock : Choice
    {
        public override bool LoseAgainst(Paper paper)
        {
            return true;
        }

        public override bool LoseAgainst(Scissors scissors)
        {
            return false;
        }

        public override bool LoseAgainst(Rock rock)
        {
            return false;
        }

        public override bool LoseAgainst(Choice choice)
        {
            return choice.LoseAgainst(this);
        }
    }
}
