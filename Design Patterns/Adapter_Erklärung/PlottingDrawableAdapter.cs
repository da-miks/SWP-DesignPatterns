using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Erklärung
{
    public class PlottingDrawableAdapter : IDrawableItem
    {
        public IPlottingMap source;
        public PlottingDrawableAdapter(IPlottingMap source) { 
            this.source = source;
        }
        public void Draw()
        {
            this.source.Plot();
        }
    }
}
