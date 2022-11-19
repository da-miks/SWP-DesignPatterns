ConcreteAggregate a = new ConcreteAggregate();
a[0] = "Item A";
a[1] = "Item B";
a[2] = "Item C";
a[3] = "Item D";

Iterator i = a.CreateIterator();

Console.WriteLine("Iterating over collection");
object item = i.First();
while(item != null)
{
    Console.WriteLine(item);
    item = i.Next();
}



public abstract class Aggregate
{
    public abstract Iterator CreateIterator();
}
public class ConcreteAggregate : Aggregate
{
    List<object> items = new List<object>();
    public override Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }
    public int Count
    {
        get
        {
            return items.Count;
        }
    }
    public object this[int index]
    {
        get
        {
            return items[index];
        }
        set
        {
            items.Insert(index, value);
        }
    }
}
public abstract class Iterator
{
    public abstract object First();
    public abstract object Next();
    public abstract bool IsDone();
    public abstract object CurrentItem();
}
public class ConcreteIterator : Iterator
{
    ConcreteAggregate aggregate;
    int current = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }
    public override object First()
    {
        return aggregate[0];
    }
    public override object Next()
    {
        object ret = null;
        if(current < aggregate.Count - 1)
        {
            ret = aggregate[++current];
        }
        return ret;
    }
    public override object CurrentItem()
    {
        return aggregate[current];
    }
    public override bool IsDone()
    {
        return current >= aggregate.Count;
    }
}

