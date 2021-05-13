using System;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = ApplicationContextFactory.CreateApplicationContext("DefaultConnection"))
            {
                if (db.Database.CanConnect())
                {
                    Console.WriteLine("Connection with Database - success!");
                }
            }

            Console.Read();
        }
    }
}
            