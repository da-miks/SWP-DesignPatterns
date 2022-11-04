using static System.Console;

var redHeadDuck = new RedheadDuck();
var duckCall = new DuckCall();
var rubberDuck = new RubberDuck();
var mallardDuck = new MallardDuck();
var gooseDuck = new GooseAdapter(new Goose());
WriteLine("Duck Simulator: With Goose Adapter");
Simulate(redHeadDuck);
Simulate(duckCall);
Simulate(rubberDuck);
Simulate(mallardDuck);
Simulate(gooseDuck);
static void Simulate(IQuackable duck) => duck.Quack();
#region Goose
public class Goose
{
    public void Honk() => WriteLine("Honk");
}
public class GooseAdapter : IQuackable
{
    private Goose _goose;

    //Constructor
    public GooseAdapter(Goose goose)
    {
        _goose = goose;
    }
    public void Quack() => _goose.Honk();
    public override string ToString() => "Goose pretending to be a duck";
}
#endregion
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