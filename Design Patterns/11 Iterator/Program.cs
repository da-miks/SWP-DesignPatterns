using static System.Console;

using System.Collections;
using System.Collections.Generic;

// Create and item collection
var collection = new ItemCollection<Item>
              {
                new Item{ Name = "Item 0"},
                new Item{ Name = "Item 1"},
                new Item{ Name = "Item 2"},
                new Item{ Name = "Item 3"},
                new Item{ Name = "Item 4"},
                new Item{ Name = "Item 5"},
                new Item{ Name = "Item 6"},
                new Item{ Name = "Item 7"},
                new Item{ Name = "Item 8"}
              };

WriteLine("Iterate front to back");
foreach (var item in collection)
{
    WriteLine(item.Name);
}

WriteLine("\nIterate back to front");
foreach (var item in collection.BackToFront)
{
    WriteLine(item.Name);
}
WriteLine();

// Iterate given range and step over even ones
WriteLine("\nIterate range (1-7) in steps of 2");
foreach (var item in collection.FromToStep(1, 7, 2))
{
    WriteLine(item.Name);
}
WriteLine();

// Wait for user
ReadKey();

/// <summary>
/// The 'ConcreteAggregate' class
/// </summary>
/// <typeparam name="T">Collection item type</typeparam>
public class ItemCollection<T> : IEnumerable<T>
{
    private readonly List<T> items = new();

    public void Add(T t) => items.Add(t);

    // The 'ConcreteIterator'
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return items[i];
        }
    }

    public IEnumerable<T> FrontToBack { get => this; }


    public IEnumerable<T> BackToFront
    {
        get
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }
    }

    public IEnumerable<T> FromToStep(int from, int to, int step)
    {
        for (int i = from; i <= to; i += step)
        {
            yield return items[i];
        }
    }

    // Gets number of items
    public int Count { get => items.Count; }

    // System.Collections.IEnumerable member implementation
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>
/// The collection item
/// </summary>
public class Item
{
    public string Name { get; set; } = null!;
}