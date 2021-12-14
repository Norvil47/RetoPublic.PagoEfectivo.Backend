using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Infraestructura.Util
{
   static  class Funciones
    {
        private static Random random = new Random();
       public static string GenerarCodigoPromocion(int longitud)
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(characters, longitud)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
