using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton._1.Lazy
{
    /// <summary>
    /// The "Singleton" Class
    /// </summary>
    public class Singleton
    {
        static Singleton instance = new Singleton();

        //Constructor is 'private'
        private Singleton()
        {

        }
        public static Singleton Instance()
        {
            // Uses lazy initialization (Späte Initialisierung)
            // Note: this is not thread safe
            // Hint: use 'lock'
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}
