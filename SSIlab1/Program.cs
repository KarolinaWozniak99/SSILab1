using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSIlab1
{
    class Program
    {
       
        static double Norm(double Min, double Max, double nMin, double nMax, double x)
        {
            double xp = ((x - Min) / (Max - Min)) * (nMax - nMin) + nMin;

            return (xp);
        }

        static void Tasuj(double[][] tab)
        {
            Random x = new Random();

            Console.WriteLine("posortowane");
            for (int i = 0; i <= tab.Length-1; i++)
            {
                for (int j = 0; j < 7; j++)
                { 

                    int r = i + x.Next(tab.Length - i);
                    double t = tab[r][j];
                    tab[r][j] = tab[i][j];
                    tab[i][j] = t;
                    Console.Write(tab[i][j]+" ");
                }
                Console.WriteLine();
            }
        }

        static double[][] Wczytaj()
        {
            string kwiat1 = "Iris-setosa";
            string kwiat2 = "Iris-versicolor";
            string kwiat3 = "Iris-virginica";

            string[] lines = File.ReadAllLines(@"baza.txt");
            double[][] dane = new double[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] tmp = lines[i].Split(',');
                dane[i] = new double[tmp.Length+2];
                for (int j = 0; j < tmp.Length; j++)
                {
                    try
                    { 
                        dane[i][j] = Convert.ToDouble(tmp[j]);
                    }
                    catch
                    {
                        if (String.Equals(tmp[j], kwiat1))
                        {
                            dane[i][4] = 0;
                            dane[i][5] = 0;
                            dane[i][6] = 1;
                        }
                        else if(String.Equals(tmp[j],kwiat2))
                        {
                            dane[i][4] = 0;
                            dane[i][5] = 1;
                            dane[i][6] = 0;
                        }
                        else if (String.Equals(tmp[j], kwiat3))
                        {
                            dane[i][4] = 1;
                            dane[i][5] = 0;
                            dane[i][6] = 0;
                        }

                    }
                }
            }
            return dane;
            
        }
      
        static void Main(string[] args)
        {
            
           
            
            var x=Wczytaj();

            for (int i = 0; i <x.Length ; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(x[i][j]+" ");
                    
                }
                Console.WriteLine();
            }

            double min = x[0][0];
            double max = x[0][0];
            double nmin = 0;
            double nmax = 1;
            double[][] newTab = new double[x.Length][];

            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (x[i][j] > max)
                        max = x[i][j];
                    if (x[i][j] < min)
                        min = x[i][j];
                }
            }
            Console.WriteLine();
            Console.WriteLine("po normalizacji");
            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    x[i][j] = Norm(min, max, nmin, nmax, x[i][j]);
                    Console.Write(x[i][j] + " ");
                }
                Console.WriteLine();
            }



            Tasuj(x);
            
            Console.ReadKey();
        }
    }
}
