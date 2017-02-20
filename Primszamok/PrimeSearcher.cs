using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primszamok
{
    class PrimeSearcher
    {       
        public static bool primszamlalo(int szam)
        {
            for (int i = 1; i < szam; i++)
            {
               
                    if (szam % i == 0)
                        return false;
                

            }
            return true;
        }
    }
}

