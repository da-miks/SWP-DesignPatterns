using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Erklärung
{
    //Ziel ist es ein IFractalGenerator Objekt in ein IDrawableItem Objekt zu adaptieren
    class FractalDrawableAdapter : IDrawableItem
    {
        //Quelle von dem IFractal Objekt
        IFractalGenerator source;
        public FractalDrawableAdapter(IFractalGenerator source)
        {
            this.source = source;
        }
        public void Draw()
        {
            this.source?.Generate();
        }

        
    }
}
