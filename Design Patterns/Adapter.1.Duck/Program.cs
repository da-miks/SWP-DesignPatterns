using static System.Console;

var mallardDuck = new MallardDuck();
var redheadDuck = new RedheadDuck();
var duckCall = new DuckCall();
var rubberDuck = new RubberDuck();
var decoyDuck = new DecoyDuck();

WriteLine("Duck Simulator");

Simulate(mallardDuck);
Simulate(redheadDuck);
Simulate(duckCall);
Simulate(rubberDuck);
Simulate(decoyDuck);

static void Simulate(IQuackable duck) => duck.Quack();

#region Duck
public interface IQuackable
{
    void Quack();
}

public class RubberDuck : IQuackable
{
    public void Quack() => WriteLine("Squeak");
}
public class RedheadDuck : IQuackable
{
    public void Quack() => WriteLine("Quack");
}
public class MallardDuck : IQuackable
{
    public void Quack() => WriteLine("Quack");
}
public class DuckCall : IQuackable
{
    public void Quack() => WriteLine("Kwak");
}
public class DecoyDuck : IQuackable
{
    public void Quack() => WriteLine("<< Silence >>");
}
#endregion