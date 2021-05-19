using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bassini_Semaforo_2
{
    class Program
    {
        public static int S;
        static Mutex m = new Mutex();       
        static SemaphoreSlim Semaforo = new SemaphoreSlim(1);
        static void Main(string[] args)
        {
            
            Thread t1 = new Thread(() =>  Procedura1());
            Thread t2 = new Thread(() => Procedura2(S));
            Semaforo.Wait();
            t1.Start();
            Semaforo.Wait();
            t2.Start();         
            Console.ReadKey();

            
        }
        static private int Procedura1()
        {
           
            int a;
            int b;
            Console.WriteLine("inserisci il 1° numero: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("\ninserisci il 2° numero: ");
            b = int.Parse(Console.ReadLine());
            S = a + b;
            Console.WriteLine($"\nla variabile a vale: {a}");
            Console.WriteLine($"\nla variabile b vale: {b}");
            Semaforo.Release();
            return S;
           
        }
        static private void Procedura2(int s)
        {
            
            int c;
            S = s;
            Random r = new Random();
            c = r.Next(10, 99);                     
            S += c;
            Console.WriteLine($"\nla variabile c vale: {S}");

        }

    }
}
