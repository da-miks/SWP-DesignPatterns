using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Erklärung
{
    class Circle : IDrawableItem
    {
        public void Draw()
        {
            Console.WriteLine("Drawing circle...");
        }
    }
}
