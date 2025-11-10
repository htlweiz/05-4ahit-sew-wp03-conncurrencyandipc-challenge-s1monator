using System;
using System.Threading;

namespace A2_RaceConditionBank;

class Program
{
    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();
        Console.WriteLine("Übung 2: Race Condition – Bankkonto");
        Console.WriteLine("==========================================\n");
        
        
        // Bankkonto mit Startwert 1000 EUR erstellen
        BankAccount account = new BankAccount(1000);
        Console.WriteLine($"Startkontostand: {account.GetBalance()} EUR\n");
        
    
    
        for (int i = 0; i < 10; i++)
        {
            Thread t = new Thread (() => PerformBankOperations(account));
            threads.Add(t);
            t.Start();
                
            

        }
        foreach (Thread thread in threads)
            {
                thread.Join();
            }
    }
    private static void PerformBankOperations(BankAccount account)
    {
        
            account.Deposit(100);
            account.Withdraw(150);
            Console.WriteLine($"Zwischenkontostand: {account.GetBalance()} EUR");
        
        
    }
    
}

