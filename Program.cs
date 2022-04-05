using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace filePath
{
    class Program
    {
        static void Main(string[] args)
        {
            string prviDirektorij = @"c:\prviDir";
            string drugiDirektorij = @"c:\drugiDir";

            if(!Directory.Exists(prviDirektorij))
            { Directory.CreateDirectory(prviDirektorij); }
            if (!Directory.Exists(drugiDirektorij))
            { Directory.CreateDirectory(drugiDirektorij); }

            string[] nazivi = new string[5];
            
            for(int i = 0;i<5;i++)
            {

                nazivi[i] = "Datoteka" + i;

                if (!File.Exists(@"c:\prviDir\"+nazivi[i]))
                {
                    File.Create(@"c:\prviDir\"+nazivi[i]);
                }
            }
            try
            {
                foreach(string datoteka in Directory.GetFiles(prviDirektorij))
                {
                    string imeDatoteke = Path.GetFileName(datoteka);
                    string ciljnaDatoteka = Path.Combine(drugiDirektorij,
                        imeDatoteke);
                    File.Copy(datoteka, ciljnaDatoteka, false);
                }
            }
            catch(Exception greska)
            {
                Console.WriteLine("Greska: {0}", greska.Message);
            }
            Console.ReadKey();
        }

    }
}
