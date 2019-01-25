using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Controller
{
    public class TransactionItemController
    {
        public void ManageTransactionItem()
        {
            Transaction transaction = new Transaction();
            TransactionItem transactionitem = new TransactionItem();
            MyContext _context = new MyContext();

            //Insert Transaction
            transaction.TransactionDate = DateTimeOffset.Now.LocalDateTime;
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            //Get ID Transaction
            var getTransaction = _context.Transactions.Max(x => x.Id);
            var getTransactionDetail = _context.Transactions.Find(getTransaction);

            Console.WriteLine("Id Transaction   : " + getTransaction);
            Console.WriteLine("Date Transaction : " + getTransactionDetail.TransactionDate);

            Console.Write("How many items : ");
            int? n = Convert.ToInt16(Console.ReadLine());
            if (n == null)
            {
                Console.WriteLine("Please insert count of item");
                Console.Read();
            } else
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Insert Item : ");
                    int? iditem = Convert.ToInt16(Console.ReadLine());

                    if (iditem == null)
                    {
                        Console.Write("Please Insert Item Id");
                        Console.Read();
                    }
                    else
                    {
                        var getitem = _context.Items.Find(iditem);
                        if (getitem == null)
                        {
                            Console.Write("We don't have Id : " + iditem);
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Insert Quantity : ");
                            int quantity = Convert.ToInt16(Console.ReadLine());
                            if (getitem.Stock < quantity)
                            {
                                Console.WriteLine("Stock not available");
                                Console.Read();
                            }
                            else
                            {
                                transactionitem.Transaction = getTransactionDetail;
                                transactionitem.Item = getitem;
                                transactionitem.Quantity = quantity;
                                _context.TransactionItems.Add(transactionitem);
                                _context.SaveChanges();
                            }
                        }
                    }
                }
                var getPrice = _context.TransactionItems.Where(x =>x.Transaction.Id == getTransactionDetail.Id).ToList();
                int? total = 0;
                foreach (var proceed in getPrice)
                {                    
                    total += (proceed.Quantity * proceed.Item.Price);
                }
                Console.WriteLine("Total Price : " + total);
                Console.Write("Balance     : ");
                int? balance = Convert.ToInt32(Console.ReadLine());
                Console.Write("Exchange    : " + (balance - total));


                Console.WriteLine("\n\n\t\t TRANSACTION " + getTransaction + "\n\n");
                Console.WriteLine(getTransactionDetail.TransactionDate.Date);
                Console.WriteLine(getTransactionDetail.TransactionDate.TimeOfDay);
                Console.WriteLine("\n-----------------------------------------------");
                Console.WriteLine(" Name\t\tQuantity\tPrice\tTotal ");
                Console.WriteLine("-----------------------------------------------");
                foreach (var nota in getPrice)
                {
                    Console.WriteLine(nota.Item.Name + "\t\t" + nota.Quantity + "\t" + nota.Item.Price + "\t" + (nota.Quantity * nota.Item.Price));
                }                
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("TOTAL\t\t\t\t\t" + total);
                Console.WriteLine("BALANCE\t\t\t\t\t" + balance);
                Console.WriteLine("EXCHANGE\t\t\t\t" + (balance - total));
                Console.Read();
            }            
        }
    }
}
