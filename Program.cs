using System;
using System.Threading;
using System.Collections.Generic;

namespace HomeWork15
{
    
    class Program
    {
        public static List<Client> ClientList = new List<Client>();
        static void Main(string[] args)
        {
            
        }
        
    }
    class Client
    {
        
        public int ID { get; set; }
        public decimal Balance { get; set; }

        public Client()
        {

        }
        public Client(int ID, decimal Balance)
        {
            this.ID = ID;
            this.Balance = Balance;
        }
        

    }

    
}
