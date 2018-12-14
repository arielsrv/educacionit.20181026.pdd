using System;

namespace Traductor
{
    class Program
    {
        static void Main(string[] args)
        {
            Target target = new Target();
            target.Request();
        }
    }
}

// Alumno o profe
class Target
{
    Adapter adapter = new Adapter();

    public void Request()
    {
        adapter.Request();
    }
}

// Han Solo
class Adapter
{
    Adaptee adaptee = new Adaptee();
    public Target Request()
    {
        RAdaptee result = adaptee.SpecificRequest();
        return new Target();
    }
}

// Chewie
class Adaptee
{
    public RAdaptee SpecificRequest()
    {
        return new RAdaptee();
    }
}

class RAdaptee
{

}