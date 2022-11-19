using static System.Console;

class Program
{
    public static void Main()
    {
        var simulator = new Program();
        var factory = new CountingDuckFactory();

        simulator.Simulate(factory);

    }

    void Simulate(AbstractDuckFactory factory)
    {
        var mallardDuck = factory.CreateMallardDuck();
        var redheadDuck = factory.CreateRedheadDuck();
        var duckCall = factory.CreateDuckCall();
        var rubberDuck = factory.CreateRubberDuck();
        var gooseDuck = new GooseAdapter(new Goose());

        WriteLine("Duck Simulator: With Abstract Factory");

        Simulate(mallardDuck);
        Simulate(redheadDuck);
        Simulate(duckCall);
        Simulate(rubberDuck);
        Simulate(gooseDuck);

        WriteLine("The ducks quacked " +
            QuackCounter.Quacks + " times");
    }

    void Simulate(IQuackable duck)
    {
        duck.Quack();
    }
}

#region Factory

public abstract class AbstractDuckFactory
{
    public abstract IQuackable CreateMallardDuck();
    public abstract IQuackable CreateRedheadDuck();
    public abstract IQuackable CreateDuckCall();
    public abstract IQuackable CreateRubberDuck();
}

public class DuckFactory : AbstractDuckFactory
{
    public override IQuackable CreateMallardDuck() => new MallardDuck();
    public override IQuackable CreateRedheadDuck() => new RedheadDuck();
    public override IQuackable CreateDuckCall() => new DuckCall();
    public override IQuackable CreateRubberDuck() => new RubberDuck();
}

public class CountingDuckFactory : AbstractDuckFactory
{
    public override IQuackable CreateMallardDuck() => new QuackCounter(new MallardDuck());
    public override IQuackable CreateRedheadDuck() => new QuackCounter(new RedheadDuck());
    public override IQuackable CreateDuckCall() => new QuackCounter(new DuckCall());
    public override IQuackable CreateRubberDuck() => new QuackCounter(new RubberDuck());
}
#endregion

#region Quack Counter

public class QuackCounter : IQuackable
{
    private readonly IQuackable _duck;

    public QuackCounter(IQuackable duck)
    {
        _duck = duck;
    }

    public void Quack()
    {
        _duck.Quack();
        Quacks++;
    }

    public static int Quacks { get; private set; }

    public override string ToString() => _duck.ToString()!;
}

#endregion

#region Ducks

public interface IQuackable
{
    void Quack();
}

public class RubberDuck : IQuackable
{
    public void Quack() => WriteLine("Squeak");

    public override string ToString() => "Rubber Duck";
}

public class RedheadDuck : IQuackable
{
    public void Quack() => WriteLine("Quack");
}

public class MallardDuck : IQuackable
{
    public void Quack() => WriteLine("Quack");

    public override string ToString() => "Mallard Duck";
}

public class DuckCall : IQuackable
{
    public void Quack() => WriteLine("Kwak");

    public override string ToString() => "Duck Call";
}

public class DecoyDuck : IQuackable
{
    public void Quack() => WriteLine("<< Silence >>");

    public override string ToString() => "Decoy Duck";
}

#endregion

#region Goose

public class GooseAdapter : IQuackable
{
    private readonly Goose _goose;

    public GooseAdapter(Goose goose)
    {
        _goose = goose;
    }

    public void Quack() => _goose.Honk();

    public override string ToString() => "Goose pretending to be a Duck";
}

public class Goose
{
    public void Honk() => WriteLine("Honk");

    public override string ToString() => "Goose";
}

#endregion