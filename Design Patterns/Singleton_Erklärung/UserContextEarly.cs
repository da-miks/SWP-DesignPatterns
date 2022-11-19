using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Erklärung
{
    class UserContextEarly
    {               
        //Bei der frühen Initialisierung besteht bereits eine statische Variable UserContext instance:
        static UserContextEarly instance = new UserContextEarly();

        //Verhindern dass ein Objekt von dieser Klasse erstellt werden kann mit private constructor:
        private UserContextEarly() { }
        //Erzeugen eines Objektes mittels statischer Eigenschaft
        public static UserContextEarly Instance
        {
            get
            {
                //bei der frühen initialisierung wird hier einfach die oben definierte Variable zurückgegeben
                return instance;
            }
        }
    }
}
