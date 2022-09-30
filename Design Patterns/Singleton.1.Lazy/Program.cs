using System.Net.WebSockets;

namespace Singleton._1.Lazy
{
    /// <summary>
    /// The 'Singleton' Class
    /// </summary>
    public class Singleton
    {
        static Singleton instance = null!;
        /*public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }*/

        //Constructor is private
        private Singleton() { }

        public static Singleton Instance()
        {
            // Uses lazy initialization
            // Note: this is not thread safe
            // Hint: use 'lock'
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Constructor is private --> cannot use new
            var s1 = Singleton.Instance;
            var s2 = Singleton.Instance;


            // Test for same instance
            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }
        }
    }
}