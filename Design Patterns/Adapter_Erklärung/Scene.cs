using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Erklärung
{
    class Scene : IDrawableItem
    {
        public List<IDrawableItem> ItemsInScene { get; set; } = new List<IDrawableItem>();
        public void Draw()
        {
            foreach (var item in ItemsInScene)
            {
                //hier soll auch die Generate Funktion von IFractalGenerator ausgegeben werden
                //Lösung ist hier der FractalDrawableAdapter
                item.Draw();
            }
        }
    }
}
