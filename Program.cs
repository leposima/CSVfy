using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;
// the motivation of the program is to read a csv file and create a .cs code file from it
// as on some environments we may not want to read directly from file and we could use 
// the outcome of this program as hard coded data structure.

// here we read a file that contains all locations and names of Alko liquer stores in Finland. 
// then we generate a c# file that has a class that will have all the data in hard coded array of Alko structs

// Leposima 2014-2015

namespace CSVfy
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter myStreamWriter = new StreamWriter(@"C:\Users\Pasi\Documents\koodi\myymalat.cs");//located in bin/debug
            myStreamWriter.WriteLine("using System;" + Environment.NewLine +
                                        "using System.Collections.Generic;" + Environment.NewLine + Environment.NewLine
                                        + "namespace CSVfy");
            myStreamWriter.WriteLine("{");
            myStreamWriter.WriteLine("class Myymalat");
            myStreamWriter.WriteLine("{");
            myStreamWriter.WriteLine("public static Alko[] alkot = {");


            TextFieldParser parser = new TextFieldParser(@"C:\Users\Pasi\Documents\koodi\alko_myymalat.csv");
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            bool once = true;
            while (!parser.EndOfData)
            {
                //Processing row
                string[] fields = parser.ReadFields();
                int index = 0;
                double longitude = 0;
                double latitude = 0;
                string nimi = string.Empty
                    ;

                if (once)
                {
                    once = false;
                }
                else
                {
                    myStreamWriter.WriteLine(",");
                }
                foreach (string field in fields)
                {


                    index++;
                    switch (index)
                    {
                        case 1:
                            longitude = double.Parse(field, System.Globalization.CultureInfo.InvariantCulture);
                            break;
                        case 2:
                            latitude = double.Parse(field, System.Globalization.CultureInfo.InvariantCulture);

                            break;
                        case 3:
                            nimi = field;
                            break;
                    }

                    //TODO: Process field

                    if (index == 3)
                        break;
                }
                myStreamWriter.WriteLine("new Alko(" + longitude.ToString(System.Globalization.CultureInfo.InvariantCulture) + "," + latitude.ToString(System.Globalization.CultureInfo.InvariantCulture) + ",\"" + nimi.ToString(System.Globalization.CultureInfo.CurrentCulture) + "\")");
            }
            parser.Close();
            myStreamWriter.WriteLine("};");
            myStreamWriter.WriteLine("}");

            myStreamWriter.WriteLine("     struct Alko");
            myStreamWriter.WriteLine("  {");
            myStreamWriter.WriteLine("     double Longitude;");
            myStreamWriter.WriteLine("    double Latitude;");
            myStreamWriter.WriteLine("     string Nimi;");

            myStreamWriter.WriteLine("     public Alko(double longitude, double latitude, string nimi)");
            myStreamWriter.WriteLine("       {");
            myStreamWriter.WriteLine("        Longitude = longitude;");
            myStreamWriter.WriteLine("        Latitude = latitude;");
            myStreamWriter.WriteLine("        Nimi = nimi;");

            myStreamWriter.WriteLine("      } ");

            myStreamWriter.WriteLine("  } ");

            myStreamWriter.WriteLine("}");


            myStreamWriter.Close();
        }
    }
}
