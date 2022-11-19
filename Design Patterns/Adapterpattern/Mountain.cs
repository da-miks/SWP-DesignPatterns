using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapterpattern
{
    public class Mountain : IGeneratorItem
    {
        public void Generate()
        {
            Console.WriteLine("Generating Mountain...");
        }
    }
}
