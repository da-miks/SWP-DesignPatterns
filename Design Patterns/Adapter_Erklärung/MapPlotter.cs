using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Erklärung
{
    public class MapPlotter : IPlottingMap
    {
        public void Plot()
        {
            Console.WriteLine("Plotting Map...");
        }
    }
}
