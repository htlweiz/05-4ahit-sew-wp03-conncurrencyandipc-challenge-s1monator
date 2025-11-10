using System;
using System.Threading;

namespace A2_RaceConditionBank;
public class BankAccount
{
    private int balance;
    private static object lockObject = new object();
   
    
    public BankAccount(int initial) 
    { 
        lock (lockObject)
        {
        balance = initial; 
        }
    }
    
    public void Deposit(int amount) 
    { 
        
        lock (lockObject)
        {
            balance += amount;
        }
        
        
       
    }
    
    public void Withdraw(int amount) 
    {
        lock (lockObject){
        balance -= amount; 
        }
    }
    
    public int GetBalance() 
    {
        lock (lockObject){
        return balance;
        }
    }
}
