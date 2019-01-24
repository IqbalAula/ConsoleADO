using Bootcamp.CRUD.Context;
using Bootcamp.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.CRUD.Controller
{
    public class ItemController
    {
        public int? idsupplier;
        public void ManageItem()
        {
            var result = 0;
            Item item = new Item();
            MyContext _context = new MyContext();
            Console.WriteLine("============== Item Data ==============");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Retrive");
            Console.WriteLine("===========================================");
            Console.Write("Pilihanmu : ");
            int pil = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("===========================================");
            switch (pil)
            {
                case 1:
                    Console.WriteLine("\tInsert Item Data");
                    Console.WriteLine("===========================================");
                    //Bagian ini untuk memasukkan nama, joindate dan create date
                    Console.Write("Insert Name of Item : ");
                    item.Name = Console.ReadLine();                    
                    Console.Write("Insert Price of Item : ");
                    item.Price = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Insert Stock of Item : ");
                    item.Stock = Convert.ToInt32(Console.ReadLine());
                    item.CreateDate = DateTimeOffset.Now.LocalDateTime;
                    Console.Write("Insert Supplier Id : ");
                    idsupplier = Convert.ToInt16(Console.ReadLine());

                    if(idsupplier == null)
                    {
                        Console.Write("Please Insert Supplier Id");
                        Console.Read();
                    }
                    else
                    {
                        var getsupplier = _context.Suppliers.Find(idsupplier);
                        if(getsupplier == null)
                        {
                            Console.Write("We don't have Id : " + idsupplier);
                            Console.Read();
                        }
                        else
                        {
                            item.Suppliers = getsupplier;
                            _context.Items.Add(item);
                            result = _context.SaveChanges();
                            if (result > 0)
                            {
                                Console.Write("Insert Successfully");
                                Console.Read();
                            }
                            else
                            {
                                Console.Write("Insert Failed");
                                Console.Read();
                            }
                        }
                    }                                          
                    break;
                case 2:
                    Console.WriteLine("\tUpdate Item Data");
                    Console.WriteLine("===========================================");
                    Console.Write("Insert Id to Update Data : ");
                    int id = Convert.ToInt16(Console.ReadLine());
                    var get = _context.Items.Find(id);
                    if (get == null)
                    {
                        Console.WriteLine("Sorry, your data is not found");
                        Console.Read();
                    }
                    else
                    {
                        Console.Write("Insert Name of Item : ");                        
                        get.Name = Console.ReadLine();
                        Console.Write("Insert Price of Item : ");
                        get.Price = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Insert Stock of Item : ");
                        get.Stock = Convert.ToInt32(Console.ReadLine());
                        get.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                        Console.Write("Insert Supplier Id : ");
                        idsupplier = Convert.ToInt16(Console.ReadLine());
                        
                        if (idsupplier == null)
                        {
                            Console.Write("Please Insert Supplier Id");
                            Console.Read();
                        }
                        else
                        {
                            var getsupplier = _context.Suppliers.Find(idsupplier);
                            if (getsupplier == null)
                            {
                                Console.Write("We don't have Id : " + idsupplier);
                                Console.Read();
                            }
                            else
                            {
                                get.Suppliers = getsupplier;
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
                        }
                        
                    }
                    break;
                case 3:
                    Console.WriteLine("\tDelete Item Data");
                    Console.WriteLine("===========================================");
                    Console.Write("Insert Id to Delete Data : ");
                    var getdata = _context.Items.Find(Convert.ToInt16(Console.ReadLine()));
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
                    Console.WriteLine("\tRetrive Item Data");
                    Console.WriteLine("===========================================");
                    var getdatadisplay = _context.Items.Where(x => x.isDelete == false).ToList();
                    if (getdatadisplay.Count == 0)
                    {
                        Console.WriteLine("No data in your database");
                        Console.Read();
                    }
                    else
                    {
                        foreach (var tampilin in getdatadisplay)
                        {
                            Console.WriteLine("====================================");
                            Console.WriteLine("Name          : " + tampilin.Name);                            
                            Console.WriteLine("Price         : " + tampilin.Price);
                            Console.WriteLine("Stock         : " + tampilin.Stock);
                            Console.WriteLine("Nama Supllier : " + tampilin.Suppliers.Name);
                            Console.WriteLine("====================================");
                        }
                        Console.Write("Total Items : " + getdatadisplay.Count);
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
