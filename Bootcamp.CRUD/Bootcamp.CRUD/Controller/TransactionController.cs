using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Controller
{
    public class TransactionController
    {
        public void ManageTransaction()
        {
            var result = 0;
            Transaction transaction = new Transaction();
            MyContext _context = new MyContext();
            //Bagian ini untuk memasukkan transactiondate
            Console.WriteLine(" Transaction ");
            transaction.TransactionDate = DateTimeOffset.Now.LocalDateTime;
            _context.Transactions.Add(transaction);
            result = _context.SaveChanges();
            if (result > 0)
            {
                Console.Write(" Insert Successfully");
                Console.Read();
            }
            else
            {
                Console.Write(" Insert Failed");
                Console.Read();
            }
        }
    }
}
