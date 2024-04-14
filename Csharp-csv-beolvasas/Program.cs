using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy; // Input Output
                              // File, StreamReader, StreamWriter

namespace Gyakrolas
{
    class Program
    {
        static readonly string file = "users.csv";

        static void Main()
        {
            List<Felhasznalo> felhasznalok = new List<Felhasznalo>();

            if (!File.Exists(file))
            {
                Console.WriteLine("Nem létezik a file!");
                Console.ReadKey();
                return;
            }

            using (StreamReader sr = new StreamReader(file))
            {
                string data = sr.ReadToEnd();

                foreach (string line in data.Split('\n'))
                {
                    if (line == "" || line == string.Empty)
                        continue;
                    string[] cellak = line.Split(';');
                    Felhasznalo felhasznalo = new Felhasznalo();
                    felhasznalo.id = int.Parse(cellak[0]);
                    felhasznalo.username = cellak[1];
                    felhasznalo.password = cellak[2].Trim();

                    felhasznalok.Add(felhasznalo);
                }
            }

            Console.WriteLine("Kérem a felhasználónevet: ");
            string input_username = Console.ReadLine();
            Console.WriteLine("Kérem a jelszót: ");
            string input_password = Console.ReadLine();

            //felhaszvizsgal = adatbázisban lévő username összehasonlítása a bevitt felhasználónévvel, hogy megegyezik-e
            foreach (Felhasznalo felhaszvizsgal in felhasznalok)
            { 
                if (felhaszvizsgal.username == input_username)
                {
                    Console.WriteLine("A felhasználónév helyes!");
                    continue;
                }
                else
                {
                    Console.WriteLine("Rossz felhasználónevet adtál meg!");
                }

                if (felhaszvizsgal.password == input_password)
                {
                    Console.WriteLine("A jelszó helyes!");
                    continue;
                }
                else
                {
                    Console.WriteLine("Rossz a jelszó!");
                }
                
            }
            Console.ReadKey();
        }

        struct Felhasznalo
        {
            public int id;
            public string username;
            public string password;
        }
    }
}