using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVfy
{
     struct Alko
    {
        double Longitude;
        double Latitude;
        string Nimi;

        public Alko(double longitude, double latitude, string nimi)
        {
            Longitude = longitude;
            Latitude = latitude;
            Nimi = nimi;

        }
   
    }

     class Moi
    {
        Alko[] alkot = { new Alko(0, 0, ""), new Alko(0, 0, "") };
    }
}
