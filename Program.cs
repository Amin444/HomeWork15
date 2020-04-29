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

            bool circle = true;
            while (circle)
            {
                System.Console.WriteLine("Choose method:");
                Console.WriteLine("1.Add ID and Balance client");
                System.Console.WriteLine("2.Select ID and Balance client");
                System.Console.WriteLine("3.Update ID and Balance client");
                System.Console.WriteLine("4.Delete ID and Balance client");
                System.Console.WriteLine("5.Exit");
                string select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        {
                            Thread InsertThread = new Thread(new ThreadStart(Insert));
                            InsertThread.Start();
                            InsertThread.Join();
                        }
                        break;
                    
                   
                    case "5":
                        {
                            circle = false;
                        }
                        break;

                }
            }
            
        }

        public static void Insert()
        {
            
            Console.Write("Write your ID: "); 
            int ID = int.Parse(Console.ReadLine());
            Console.Write("write your Balance: "); 
            decimal Balance = Decimal.Parse(Console.ReadLine());
            Client ClientInsert = new Client( ID, Balance);
            ClientList.Add(ClientInsert);
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