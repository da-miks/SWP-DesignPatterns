using System.Text;
using static System.Console;

var nyStore = new NewYorkPizzaStore();
var chStore = new ChicagoPizzaStore();

var pizza = nyStore.OrderPizza("cheese");
WriteLine($"Ethan ordered a {pizza.Name}\n");

pizza = chStore.OrderPizza("cheese");
WriteLine($"Joel ordered a {pizza.Name}\n");

pizza = nyStore.OrderPizza("clam");
WriteLine($"Ethan ordered a {pizza.Name}\n");

pizza = chStore.OrderPizza("clam");
WriteLine($"Joel ordered a a {pizza.Name}\n");

pizza = nyStore.OrderPizza("pepperoni");
WriteLine($"Ethan ordered a {pizza.Name}\n");

pizza = chStore.OrderPizza("pepperoni");
WriteLine($"Joel ordered a a {pizza.Name}\n");

pizza = nyStore.OrderPizza("veggie");
WriteLine($"Ethan ordered a a {pizza.Name}\n");

pizza = chStore.OrderPizza("veggie");
WriteLine($"Joel ordered a a {pizza.Name}\n");

#region Ingredient Abstract Factory

public interface IPizzaIngredientFactory
{
    IDough CreateDough();
    ISauce CreateSauce();
    ICheese CreateCheese();
    IVeggies[] CreateVeggies();
    IPepperoni CreatePepperoni();
    IClams CreateClam();
}

public class NewYorkPizzaIngredientFactory : IPizzaIngredientFactory
{
    public IDough CreateDough() => new ThinCrustDough();

    public ISauce CreateSauce() => new MarinaraSauce();

    public ICheese CreateCheese() => new ReggianoCheese();

    public IVeggies[] CreateVeggies() =>
        new IVeggies[] { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };

    public IPepperoni CreatePepperoni() => new SlicedPepperoni();

    public IClams CreateClam() => new FreshClams();
}

public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
{
    public IDough CreateDough() => new ThickCrustDough();

    public ISauce CreateSauce() => new PlumTomatoSauce();

    public ICheese CreateCheese() => new MozzarellaCheese();

    public IVeggies[] CreateVeggies() =>
        new IVeggies[] { new BlackOlives(), new Spinach(), new Eggplant() };

    public IPepperoni CreatePepperoni() => new SlicedPepperoni();

    public IClams CreateClam() => new FrozenClams();
}

#endregion

#region Pizza Stores

public abstract class PizzaStore
{
    public Pizza OrderPizza(string type)
    {
        var pizza = CreatePizza(type);
        WriteLine($"--- Making a {pizza.Name} ---");

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }

    public abstract Pizza CreatePizza(string item);
}

public class NewYorkPizzaStore : PizzaStore
{
    public override Pizza CreatePizza(string item)
    {
        var ingredientFactory = new NewYorkPizzaIngredientFactory();

        return item switch
        {
            "cheese" => new CheesePizza(ingredientFactory) { Name = "New York Style Cheese Pizza" },
            "veggie" => new VeggiePizza(ingredientFactory) { Name = "New York Style Veggie Pizza" },
            "clam" => new ClamPizza(ingredientFactory) { Name = "New York Style Clam Pizza" },
            "pepperoni" => new PepperoniPizza(ingredientFactory) { Name = "New York Style Peperoni Pizza" },
            _ => null!
        };
    }
}

public class ChicagoPizzaStore : PizzaStore
{
    // Factory method implementation
    public override Pizza CreatePizza(string item)
    {

        var ingredientFactory = new ChicagoPizzaIngredientFactory();

        return item switch
        {
            "cheese" => new CheesePizza(ingredientFactory) { Name = "Chicago Style Cheese Pizza" },
            "veggie" => new VeggiePizza(ingredientFactory) { Name = "Chicago Style Veggie Pizza" },
            "clam" => new ClamPizza(ingredientFactory) { Name = "Chicago Style Clam Pizza" },
            "pepperoni" => new PepperoniPizza(ingredientFactory) { Name = "Chicago Style Peperoni Pizza" },
            _ => null!
        };
    }
}

#endregion

#region Pizzas

public abstract class Pizza
{
    protected IDough dough = null!;
    protected ISauce sauce = null!;
    protected IVeggies[] veggies = null!;
    protected ICheese cheese = null!;
    protected IPepperoni pepperoni = null!;
    protected IClams clam = null!;

    private string name = null!;

    public abstract void Prepare();

    public void Bake()
    {
        WriteLine("Bake for 25 minutes at 350");
    }

    public virtual void Cut()
    {
        WriteLine("Cutting the pizza into diagonal slices");
    }

    public void Box()
    {
        WriteLine("Place pizza in official Pizzastore box");
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append($"---- {this.Name} ----\n");
        if (dough != null)
        {
            result.Append(dough);
            result.Append("\n");
        }
        if (sauce != null)
        {
            result.Append(sauce);
            result.Append("\n");
        }
        if (cheese != null)
        {
            result.Append(cheese);
            result.Append("\n");
        }
        if (veggies != null)
        {
            for (int i = 0; i < veggies.Length; i++)
            {
                result.Append(veggies[i]);
                if (i < veggies.Length - 1)
                {
                    result.Append(", ");
                }
            }
            result.Append("\n");
        }
        if (clam != null)
        {
            result.Append(clam);
            result.Append("\n");
        }
        if (pepperoni != null)
        {
            result.Append(pepperoni);
            result.Append("\n");
        }
        return result.ToString();
    }
}

public class ClamPizza : Pizza
{
    private readonly IPizzaIngredientFactory _ingredientFactory;

    public ClamPizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
    }

    public override void Prepare()
    {
        WriteLine($"Preparing {this.Name}");
        dough = _ingredientFactory.CreateDough();
        sauce = _ingredientFactory.CreateSauce();
        cheese = _ingredientFactory.CreateCheese();
        clam = _ingredientFactory.CreateClam();
    }
}

public class CheesePizza : Pizza
{
    private readonly IPizzaIngredientFactory _ingredientFactory;

    public CheesePizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
    }

    public override void Prepare()
    {
        WriteLine($"Preparing {this.Name}");
        dough = _ingredientFactory.CreateDough();
        sauce = _ingredientFactory.CreateSauce();
        cheese = _ingredientFactory.CreateCheese();
    }
}

public class PepperoniPizza : Pizza
{
    private readonly IPizzaIngredientFactory _ingredientFactory;

    public PepperoniPizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
    }

    public override void Prepare()
    {
        WriteLine($"Preparing {this.Name}");
        dough = _ingredientFactory.CreateDough();
        sauce = _ingredientFactory.CreateSauce();
        cheese = _ingredientFactory.CreateCheese();
        veggies = _ingredientFactory.CreateVeggies();
        pepperoni = _ingredientFactory.CreatePepperoni();
    }
}

public class VeggiePizza : Pizza
{
    private readonly IPizzaIngredientFactory _ingredientFactory;

    public VeggiePizza(IPizzaIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
    }

    public override void Prepare()
    {
        WriteLine($"Preparing {this.Name}");
        dough = _ingredientFactory.CreateDough();
        sauce = _ingredientFactory.CreateSauce();
        cheese = _ingredientFactory.CreateCheese();
        veggies = _ingredientFactory.CreateVeggies();
    }
}

#endregion

#region Ingredients

public class ThinCrustDough : IDough
{
    public override string ToString() => "Thin Crust Dough";
}

public class ThickCrustDough : IDough
{
    public override string ToString() => "ThickCrust style extra thick crust dough";
}

public class Spinach : IVeggies
{
    public override string ToString() => "Spinach";
}

public class SlicedPepperoni : IPepperoni
{
    public override string ToString() => "Sliced Pepperoni";
}

public interface ISauce
{
    string ToString();
}
public interface IDough
{
    string ToString();
}
public interface IClams
{
    string ToString();
}
public interface IVeggies
{
    string ToString();
}
public interface ICheese
{
    string ToString();
}

public interface IPepperoni
{
    string ToString();
}

public class Garlic : IVeggies
{
    public override string ToString() => "Garlic";
}

public class Onion : IVeggies
{
    public override string ToString() => "Onion";
}

public class Mushroom : IVeggies
{
    public override string ToString() => "Mushrooms";
}

public class Eggplant : IVeggies
{
    public override string ToString() => "Eggplant";
}

public class BlackOlives : IVeggies
{
    public override string ToString() => "Black Olives";
}

public class RedPepper : IVeggies
{
    public override string ToString() => "Red Pepper";
}

public class PlumTomatoSauce : ISauce
{
    public override string ToString() => "Tomato sauce with plum tomatoes";
}
public class MarinaraSauce : ISauce
{
    public override string ToString() => "Marinara Sauce";
}

public class FreshClams : IClams
{
    public override string ToString() => "Fresh Clams from Long Island Sound";
}
public class FrozenClams : IClams
{
    public override string ToString() => "Frozen Clams from Chesapeake Bay";
}

public class ParmesanCheese : ICheese
{
    public override string ToString() => "Shredded Parmesan";
}

public class MozzarellaCheese : ICheese
{
    public override string ToString() => "Shredded Mozzarella";
}

public class ReggianoCheese : ICheese
{
    public override string ToString() => "Reggiano Cheese";
}
#endregion