using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;

namespace Frontend
{
    class Program
    {
        static void Main()
        {
              var personManager = new PersonManager();
              var personViewManager = new PersonViewManager(personManager);
              personViewManager.StartMainLoop();
        }
    }
}
