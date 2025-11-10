using System;
using System.Threading;

namespace A1_ZweiThreadsZaehlenWinner;

class Program
{
   
    static int acount = 0;
    static int bcount = 0;
    public static void Main(string[] args)
    {
        Console.WriteLine("Übung 1: Zwei Threads – Zählen & Winner");
        Thread thread1 = new Thread(CountUpThreadA);
        Thread thread2 = new Thread(CountDownThreadB);
        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        if (acount == bcount)
        {
            Console.WriteLine($"Unentschieden");
        }
        else if (acount < 50)
        {
            Console.WriteLine($"Gewonnen hat: Thread B !");
        }
        else
        {
            Console.WriteLine($"Gewonnen hat: Thread A!");
        }
        
   
        
        
    }
    
    private static void CountUpThreadA()
    {
        
        for (int i = 1; i <= 100; i++)
        {
            acount = i;
            Console.WriteLine($"{i}");
            Thread.Sleep(100);
        if (bcount == acount){
            break;
        }
        
        }
            
    }
    
    private static void CountDownThreadB()
    {
        
        for (int i = 100; i >= 1; i--)
        {
            bcount = i;
            Console.WriteLine($"{i}");
            Thread.Sleep(100);
        if (acount == bcount){
            break;
        
        }
        
    }
}
}
