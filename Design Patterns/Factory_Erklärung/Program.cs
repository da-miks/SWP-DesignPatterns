
List<CarCreator> carCreatorList = new List<CarCreator>();
carCreatorList.Add(new FordCreator());
carCreatorList.Add(new MercedesCreator());
foreach (var item in carCreatorList)
{
    Car currentCar = item.CreatingFunction();
    Console.WriteLine($"Created: {currentCar.GetType().Name}");
}

abstract class Car
{

}
class Ford : Car
{

}
class Mercedes : Car
{

}
abstract class CarCreator
{
    public abstract Car CreatingFunction();
}
class FordCreator : CarCreator
{
    public override Car CreatingFunction()
    {
        return new Ford();
    }
}
class MercedesCreator : CarCreator
{
    public override Car CreatingFunction()
    {
        return new Mercedes();
    }
}
