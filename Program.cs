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
            

            TimerCallback timer = new TimerCallback(CheckBalance);
            Timer tm = new Timer(timer, ClientList, 0, 10000);

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
                    case "2":
                        {
                            Thread SelectThread = new Thread(new ThreadStart(Select));
                            SelectThread.Start();
                            SelectThread.Join();
                        }
                        break;
                    case "3":
                        {
                            Thread UpdateThread = new Thread(new ThreadStart(Update));
                            UpdateThread.Start();
                            UpdateThread.Join();
                        }
                    break;  
                case "4":
                       {
                            Thread DeleteThread = new Thread(new ThreadStart(DeleteById));
                            DeleteThread.Start();
                            DeleteThread.Join();
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.Write("Write your ID: "); 
            int ID = int.Parse(Console.ReadLine());
            Console.Write("write your Balance: "); 
            decimal Balance = Decimal.Parse(Console.ReadLine());
            decimal LastBalance = Balance;
            Client ClientInsert = new Client( ID, Balance, LastBalance);
            ClientList.Add(ClientInsert);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Select()
        {
            Console.Clear();
            foreach (var client in ClientList)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"ID: {client.ID}\nBalance: {client.Balance}");
                Console.WriteLine("=============================================================");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Update()
        {
            Console.Clear();
             Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Write for update your Balance: "); 
            decimal Balance = Decimal.Parse(Console.ReadLine());
            foreach (var client in ClientList)
            {
                client.Balance = Balance;
            }
             Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DeleteById()
        {
            Console.Clear();
            Console.Write("Write your ID for delete client: "); 
            int idClient = int.Parse(Console.ReadLine());
            foreach (var client in ClientList)
            {
                if (idClient== client.ID)
                {
                    ClientList.Remove(client);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"ID client {idClient} deleted success");
                    Console.WriteLine("=============================================================");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }

        

            public static void CheckBalance(object p)
        {
            int i = 0;
            foreach (var x in ClientList)
            {
                if (x.Balance > x.LastBalance)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" Client ID {x.ID}  balance after changed is {x.Balance} > {x.LastBalance} <- this is last balance  [+]");
                    ClientList[i].LastBalance = ClientList[i].Balance;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (x.Balance < x.LastBalance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($" Client ID {x.ID} balance after changed is {x.Balance} < {x.LastBalance} <- this is last balance [-]");
                    ClientList[i].LastBalance = ClientList[i].Balance;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                i++;
            }
        }
        
    }

    class Client
    {
        
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public decimal LastBalance{get;set;}
         public Client()
         {

         }
        public Client(int ID, decimal Balance, decimal LastBalance)
        {
            this.ID = ID;
            this.Balance = Balance;
            this.LastBalance = LastBalance;
        }
       
    }
}