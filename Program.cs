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
            Client ClientInsert = new Client( ID, Balance);
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