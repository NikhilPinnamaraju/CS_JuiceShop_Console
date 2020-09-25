using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuiceShopBusinessManager;
using JuiceShopEntities;
namespace JuiceShopClient
{
    class Program
    {
        static void Main(string[] args)
        {
            juiceshopmanager dal = new juiceshopmanager();
            dal.removeolddata();
            Console.WriteLine("Available Juice Flavors:");
            Console.WriteLine("==========================");
            Console.WriteLine("ID\tFlavor\tPrice");
            Console.WriteLine("==========================");


            List<juice> lst = dal.GetJuiceFlavors();
                foreach (juice j in lst)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", j.juice_id,j.juice_flavor, j.price);
                }

            Console.Write("enter juiceid:");
           int i = int.Parse(Console.ReadLine());
            Console.Write("enter quantity:");
            int q = int.Parse(Console.ReadLine());

            dal.choicejuices(i, q);

           Console.WriteLine("want to continue more y/n");
            string choice = (Console.ReadLine());

            if (choice == "y")
            {
                do
                {

                    Console.WriteLine("Available Juice Flavors:");
                    Console.WriteLine("==========================");
                    Console.WriteLine("ID\tFlavor\tPrice");
                    Console.WriteLine("==========================");


                    foreach (juice e in lst)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t", e.juice_id, e.juice_flavor, e.price);
                    }
                    Console.WriteLine("Enter the Juice Flavor Id:");
                    int fid = int.Parse(Console.ReadLine());
                    Console.Write("enter the quantity:");
                    int qty = int.Parse(Console.ReadLine());
                    dal.choicejuices(fid,qty);
                    Console.WriteLine("want to continue more y/n");
                    choice = (Console.ReadLine());
                } while (choice == "y");


               } 
           
            List<JuicePurchased> j3 = dal.Alljuicepurchased();
          
           int v= 0;

            foreach (JuicePurchased jp in j3)
            {

               v= v + jp.amount;
            }
            Console.WriteLine("Total Purchase:{0}",+v);

        }
    }
}

