using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapterpattern
{
    public class GenratorDrawableAdapter : IDrawableItem
    {
        IGeneratorItem item;
        public GenratorDrawableAdapter(IGeneratorItem item)
        {
            this.item = item;
        }
        public void Draw()
        {
            item.Generate();
        }
    }
}
