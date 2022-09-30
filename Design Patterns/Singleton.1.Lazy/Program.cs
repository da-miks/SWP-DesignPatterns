using Singleton._1;
namespace Singleton._1.Lazy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Constructor is private -- cannot use new
            var s1 = Singleton.Instance();
            var s2 = Singleton.Instance();

            //Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
        }
    }

}



