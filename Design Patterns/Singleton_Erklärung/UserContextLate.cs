using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Erklärung
{
    class UserContextLate
    {
        //Bei der späten Initialisierung wird nur die Variable selbst deklariert doch noch nicht implementiert
        static UserContextLate instance;

        public int UserId { get; set; }
        public string Username { get; set; }
        public void Load()
        {
            //Load data from somewhere
        }
        //Verhindern dass ein Objekt von dieser Klasse erstellt werden kann mit private constructor
        private UserContextLate() { }

        //Erzeugen eines Objektes mittels statischer Eigenschaft
        static UserContextLate Instance
        {
            get
            {
                //bei der späten initialisierung wird hier geprüft ob die deklarierte variable schon zugewiesen wurde sonst wird sie hier implementiert
                if (instance == null)
                {
                    instance = new UserContextLate();
                }
                return instance;
            }
        }

    }
}
