using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc {
    internal class Szamologep {
        static void Addolas(string a, List<char> operatorok, List<double> szamok) { 
             string seged = "";

            foreach (char i in a) {
                if (char.IsDigit(i)) {
                    seged += i;
                }
                else {
                    operatorok.Add(i);
                    szamok.Add(double.Parse(seged));
                    seged = "";
                }
            }

            if (seged != "") {
                szamok.Add(double.Parse(seged));
            }
        }
        static void Szorzas_Osztas(List<char> operatorok, List<double> szamok) {
            for (int i = operatorok.Count - 1; i >= 0; i--) {
                if (operatorok[i] == '*') {
                    double szorzo_eredmeny = szamok[i] * szamok[i + 1];
                    szamok[i] = szorzo_eredmeny;
                    szamok.RemoveAt(i + 1);
                    operatorok.RemoveAt(i);
                }
                else if (operatorok[i] == '/') {
                    if (szamok[i + 1] != 0) {
                        double oszto_eredmeny = szamok[i] / szamok[i + 1];
                        szamok[i] = oszto_eredmeny;
                        szamok.RemoveAt(i + 1);
                        operatorok.RemoveAt(i);
                    }
                    else {
                        Console.WriteLine("0-val nem lehet osztani!");
                        return;
                    }

                }
            }
        }
        static void Eredmeny(List<char> operatorok, List<double> szamok) {
            double eredmeny = szamok[0];

            for (int i = 0; i < operatorok.Count; i++) {
                if (operatorok[i] == '+') {
                    eredmeny += szamok[i + 1];
                }
                if (operatorok[i] == '-') {
                    eredmeny -= szamok[i + 1];
                }

            }

            Console.WriteLine(eredmeny);
        }
        static void Main(string[] args) {
            List<char> operatorok = new List<char>();
            List<double> szamok = new List<double>();
            string a = Console.ReadLine();
            Addolas(a, operatorok, szamok);

            Szorzas_Osztas(operatorok, szamok);

            Eredmeny(operatorok, szamok);

            Console.ReadKey(); 
        }
    }
}
