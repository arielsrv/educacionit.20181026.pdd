using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreacionDeObjetos
{
    class Program
    {
        static void Main(string[] args)
        {
            BallFactory ballFactory = new BallFactory();

            Ball greenBall1 = ballFactory.GetBall("green");
            Console.WriteLine(greenBall1.X);
            Console.WriteLine(greenBall1.Y);

            Ball greenBall2 = ballFactory.GetBall("green");
            Console.WriteLine(greenBall2.X);
            Console.WriteLine(greenBall2.Y);
        }
    }

    class BallFactory
    {
        private Dictionary<string, Ball> balls = new Dictionary<string, Ball>();

        public Ball GetBall(string color)
        {
            Ball ball = null;

            if (balls.ContainsKey(color))
            {
                ball = balls[color];
            }
            else
            {
                switch (color)
                {
                    case "red": ball = new RedBall(); break;
                    case "green": ball = new GreenBall(); break;
                }
                balls.Add(color, ball);
            }

            return ball;
        }
    }

    class Ball
    {
        public string Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    class RedBall : Ball
    {

    }

    class GreenBall : Ball
    {

    }
}