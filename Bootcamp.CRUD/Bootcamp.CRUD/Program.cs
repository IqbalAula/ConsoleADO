using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Context.Model;
using Bootcamp.CRUD.Controller;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD
{
    class Program
    {
        static void Main(string[] args)
        {            
            SupplierController supplier = new SupplierController();
            ItemController item = new ItemController();
            TransactionItemController transactionitem = new TransactionItemController();
            Console.WriteLine("============== Manage Data ==============");
            Console.WriteLine("1. Data Supplier");
            Console.WriteLine("2. Data Item");
            Console.WriteLine("3. Transaction");
            Console.WriteLine("===========================================");
            Console.Write(" Pilihanmu : ");
            int pil = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===========================================");
            switch (pil)
            {
                case 1:
                    supplier.ManageSupplier();                   
                    break;
                case 2:
                    item.ManageItem();
                    break;
                case 3:
                    transactionitem.ManageTransactionItem();
                    break;
                default:
                    Console.WriteLine(" Something wrong, please try again next time");
                    break;

            }
        }
    }
}
