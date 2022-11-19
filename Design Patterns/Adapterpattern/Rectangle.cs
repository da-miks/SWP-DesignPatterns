using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapterpattern
{
    public class Rectangle : IDrawableItem
    {
        public void Draw()
        {
            Console.WriteLine("Drawing a Rectangle...");
        }
    }
}
