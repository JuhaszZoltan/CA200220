using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CA200220
{
    struct Cica
    {
        public string Nev { get; set; }
        public int Kor { get; set; }
        public float Suly { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cicak = new Cica[]
            {
                new Cica()
                {
                    Nev = "Cirmi",
                    Kor = 10,
                    Suly = 11.3F,
                },
                new Cica()
                {
                    Nev = "Kormi",
                    Kor = 11,
                    Suly = 8.5F,
                },
                new Cica()
                {
                    Nev = "Dezső",
                    Kor = 8,
                    Suly = 12F,
                },
                new Cica()
                {
                    Nev = "Flaffy",
                    Kor = 8,
                    Suly = 12F,
                },
            };

            string dagadtMacskaNeve = cicak.Where(
                x => x.Suly == cicak.Max(c => c.Suly))
                .Select(x => x.Nev)
                .ToArray().First();

            string dmn = (from c in cicak
                          where c.Suly == 12
                          select c.Nev).FirstOrDefault();

            if (dmn is null) 
                Console.WriteLine("nincs ilyen");
            else Console.WriteLine(dmn);

            var dta = cicak.GroupBy(c => c.Suly, c => c.Nev);
                //.ToDictionary(x => x.Key, x => x.ToList());

            foreach (var i in dta)
            {
                Console.WriteLine(i.Key);
                foreach (var n in i)
                {
                    Console.WriteLine($"\t{n}");
                }
            }


            Console.ReadKey();


        }
    }
}
