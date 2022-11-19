using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapterpattern
{
    public class Scene
    {
        public List<IDrawableItem> List { get; set; } = new List<IDrawableItem>();

        public void MakeScene()
        {
            foreach (var item in List)
            {
                item.Draw();
            }
        }
    }
}
