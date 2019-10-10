using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019probazhB
{
    class Program
    {



        static int[,] ForgalomGeneral(int[,] forgalom)
        {
            Random rnd = new Random();

            
            for (int i = 0; i < forgalom.GetLength(0); i++)
            {
                for (int j = 0; j < forgalom.GetLength(1); j++)
                {
                   if(i==0)
                    {
                        forgalom[i, j] = rnd.Next(50, 301);
                    }
                   else if(i==1)
                    {
                        forgalom[i, j] = rnd.Next(20, 124);
                    }
                    else
                    {
                        forgalom[i, j] = rnd.Next(0,201);
                    }
                }

            }
            return forgalom;
        }

        static int LeghosszabbVonatNev(string [] tipusok)
        {
            int hmax = 0;
            for (int i = 0; i < tipusok.Length; i++)
            {if(tipusok[i].Length>hmax)
                {
                    hmax = tipusok[i].Length;
                }

            }
            return hmax;
        }

        

        static string ForgalomSzovegkent(string[] tipusok ,int[,] forgalom)
        {
            int adat=LeghosszabbVonatNev(tipusok);
            string s = "";
            s += "\tH" + "\tK" + "\tS" + "\tC" + "\tP" + "\tS" + "\tV";
            s += "\n";

                for (int i = 0; i < forgalom.GetLength(0); i++)
                {
                s = s + tipusok[i];

                for (int j = 0; j < adat; j++)
                    {
                        s = s + "\t" + (forgalom[i, j]);
                    

                    }
                s = s + "\n";
            }

            
            return s;
        }


        static int VonatKeres(string[] tipusok, string keresett)
        {
            int az = 0;
            for (int i = 0; i < tipusok.Length; i++)
            {
                if (keresett == tipusok[i])
                {
                    az= 0;
                }
                else  az=-1;

            }
            return az;
        }

        

        static int OsszTipusForgalom(int[,] forgalom, int tipusIdx)
        {
            int osszes = 0;
            for (int i = 0; i < forgalom.GetLength(0); i++)
            {
                for (int j = 0; j < forgalom.GetLength(1); j++)
                {
                    if (tipusIdx == i)
                    {
                        osszes = osszes + forgalom[tipusIdx,j];
                    }
                }
             

            }
            return osszes;
        }


        static double OsszAtlag(int[,] forgalom)
        {
           
            int osszeg = 0;
            for (int i = 0; i < forgalom.GetLength(0); i++)
            {
                osszeg = osszeg + (OsszTipusForgalom(forgalom, i)); 
            }
      
            return osszeg/forgalom.GetLength(0);
        }


        static int GyakoriVonatDb(int[,] forgalom)
        {
            int gyak = 0;
            for (int i = 0; i < 6; i++)
            {
                if(OsszTipusForgalom(forgalom, i)>500)
                {
                    gyak++; ;
                }

            }
            return gyak;
        }
        
        static void Main(string[] args)
        {


            
            string[] tipusok = { "Szili", "Flirt", "Desiro", "Fecske", "Railjet", "Csörgő" };


            int tipusokszama = tipusok.Length;
            int napokszama = 7;
            int[,] forgalom = new int[tipusokszama,napokszama];
            int[,] Forgalom = ForgalomGeneral(forgalom);
            Console.WriteLine( ForgalomSzovegkent(tipusok, Forgalom));
            Console.WriteLine(VonatKeres(tipusok, "Pina"));
            Console.WriteLine(OsszTipusForgalom(forgalom,4));
            Console.WriteLine(OsszAtlag(forgalom));
            Console.WriteLine(GyakoriVonatDb(forgalom));


            Console.ReadLine();
        }
    }
}
