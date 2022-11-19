StrategyPicker picker;

picker = new StrategyPicker(new PlayerStrategyA());
picker.StrategicPlay();

picker = new StrategyPicker(new PlayerStrategyB());
picker.StrategicPlay();

picker = new StrategyPicker(new PlayerStrategyC());
picker.StrategicPlay();

public abstract class PlayerStrategy
{
    public abstract void StrategicPlay();
}
public class PlayerStrategyA : PlayerStrategy
{
    public override void StrategicPlay()
    {
        Console.WriteLine("PlayerStrategy A selected");
    }
}
public class PlayerStrategyB : PlayerStrategy
{
    public override void StrategicPlay()
    {
        Console.WriteLine("PlayerStrategy B selected");
    }
}
public class PlayerStrategyC : PlayerStrategy
{
    public override void StrategicPlay()
    {
        Console.WriteLine("PlayerStrategy C selected");
    }
}

public class StrategyPicker
{
    PlayerStrategy playerStrategy;
    public StrategyPicker(PlayerStrategy playerStrategy)
    {
        this.playerStrategy = playerStrategy;
    }
    public void StrategicPlay()
    {
        playerStrategy.StrategicPlay();
    }
}