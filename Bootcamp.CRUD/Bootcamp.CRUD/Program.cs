using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Context.Model;
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
            var result = 0;
            Supplier supplier = new Supplier();
            MyContext _context = new MyContext();
            Console.WriteLine("============== Supplier Data ==============");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Dalete");
            Console.WriteLine("4. Retrive");
            Console.WriteLine("===========================================");
            Console.Write("Pilihanmu : ");
            int pil = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===========================================");
            switch (pil)
            {
                case 1:
                    Console.WriteLine("\tInsert Supplier Data");
                    Console.WriteLine("===========================================");
                    //Bagian ini untuk memasukkan nama, joindate dan create date
                    Console.Write("Insert Name of Supplier : ");
                    supplier.Name = Console.ReadLine();
                    supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
                    supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
                    _context.Suppliers.Add(supplier);
                    result = _context.SaveChanges();
                    if(result > 0)
                    {
                        Console.Write("Insert Successfully");
                        Console.Read();
                    } else
                    {
                        Console.Write("Insert Failed");
                        Console.Read();
                    }                    
                    break;
                case 2:
                    Console.WriteLine("\tUpdate Supplier Data");
                    Console.WriteLine("===========================================");
                    Console.Write("Insert Id to Update Data : ");
                    int id = Convert.ToInt16(Console.ReadLine());
                    var get = _context.Suppliers.Find(id);
                    if (get == null)
                    {
                        Console.WriteLine("Sorry, your data is not found");
                        Console.Read();
                    }
                    else
                    {
                        Console.Write("Insert Name of Supplier : ");
                        get.Name = Console.ReadLine();
                        get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                        
                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.Write("Update Successfully");
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Update Failed");
                            Console.Read();
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("\tDelete Supplier Data");
                    Console.WriteLine("===========================================");
                    Console.Write("Insert Id to Delete Data : ");
                    var getdata = _context.Suppliers.Find(Convert.ToInt16(Console.ReadLine()));
                    if (getdata == null)
                    {
                        Console.WriteLine("Sorry, your data is not found");
                        Console.Read();
                    }
                    else
                    {
                        //jika ada, maka akan mengubah status isDelete dan disimpan di database
                        getdata.isDelete = true;
                        getdata.DeleteDate = DateTimeOffset.Now.LocalDateTime;

                        result = _context.SaveChanges();
                        if (result > 0)
                        {
                            Console.Write("Delete Successfully");
                            Console.Read();
                        }
                        else
                        {
                            Console.Write("Delete Failed");
                            Console.Read();
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("\tRetrive Supplier Data");
                    Console.WriteLine("===========================================");
                    var getdatadisplay = _context.Suppliers.Where(x => x.isDelete == false).ToList();
                    if (getdatadisplay.Count == 0)
                    {
                        Console.WriteLine("No data in your database");
                        Console.Read();
                    } else
                    {
                        foreach(var tampilin in getdatadisplay)
                        {
                            Console.WriteLine("====================================");
                            Console.WriteLine("Name        : " + tampilin.Name);
                            Console.WriteLine("Join Date   : " + tampilin.JoinDate);
                            Console.WriteLine("====================================");
                        }
                        Console.Write("Total Supplier : " + getdatadisplay.Count);
                        Console.Read();
                    }
                    break;
                default:
                    Console.WriteLine("Something wrong, please try again next time");
                    break;

            }
        }
    }
}
