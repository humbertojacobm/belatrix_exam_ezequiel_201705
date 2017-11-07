using Belatrix.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.UI.Consol
{
    class Program
    {
        static void Main(string[] args)
        {
           
            System.Console.WriteLine("Esperando por mensaje");
            
            JobLogger _JobLogger = new JobLogger(true, true, true, true, true, true);
            _JobLogger.LogMessage("Mensaje de prueba", false, true, false);

            System.Console.ReadKey();


        }
    }
}
