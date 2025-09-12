// See https://aka.ms/new-console-template for more information

using DryIoc;

Console.WriteLine("Hello, World!");


var c = new Container();
c.Register<IA, A>();
c.Register<B>();

var a = c.Resolve<IA>();
a.Log("Bleah");

var b = c.Resolve<B>();
b.Log("Bleah");

interface IA
{
    void Log(string message);
}

public class B
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
public class A : IA
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}