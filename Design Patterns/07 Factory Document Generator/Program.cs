using static System.Console;

// Document constructors call Factory Method
var documents = new List<Document> {
                new Resume(),
                new Report()
            };

// Display document pages
foreach (var document in documents)
{
    document.CreatePages();  // Factory method

    WriteLine($"{document} --");
    foreach (var page in document.Pages) WriteLine($" {page}");
    WriteLine();
}


/// <summary>
/// The 'Product' abstract class
/// </summary>
public abstract class Page
{
    // Override. Display class name
    public override string ToString() => GetType().Name;
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
public class SkillsPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
public class EducationPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
public class ExperiencePage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
public class IntroductionPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>    
public class ResultsPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
public class ConclusionPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
public class SummaryPage : Page
{
}

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
public class BibliographyPage : Page
{
}

/// <summary>
/// The 'Creator' abstract class
/// </summary>
public abstract class Document
{
    // Gets list of document pages
    public List<Page> Pages { get; protected set; } = null!;

    // Factory Method
    public abstract void CreatePages();

    // Override
    public override string ToString() => GetType().Name;
}

/// <summary>
/// A 'ConcreteCreator' class
/// </summary>
public class Resume : Document
{
    // Factory Method implementation
    public override void CreatePages()
    {
        Pages = new()
        {
            new SkillsPage(),
            new EducationPage(),
            new ExperiencePage()
        };
    }
}

/// <summary>
/// A 'ConcreteCreator' class
/// </summary>
public class Report : Document
{
    // Factory Method implementation
    public override void CreatePages()
    {
        Pages = new()
        {
            new IntroductionPage(),
            new ResultsPage(),
            new ConclusionPage(),
            new SummaryPage(),
            new BibliographyPage()
        };
    }
}
