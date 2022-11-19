using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Erklärung
{
    class MountainGenerator : IFractalGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating Mountains...");
        }
    }
}
