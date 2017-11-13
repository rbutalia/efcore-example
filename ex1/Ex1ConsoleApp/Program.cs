using ef1.Data;
using ex1.Domain;
using System;

namespace Ex1ConsoleApp
{
    class Program
    {
        private static Ex1DataContext _context = new Ex1DataContext();
        static void Main(string[] args)
        {
            //InsertCompany();
            Console.WriteLine("Hello World!");
        }


        private static void InsertCompany()
        {
            var ex1 = new Company { CompanyName = "Manit Company", SalesTax = 0.13m, TextIdentifier = "CA", CreatedBy = "Randeep B", CreatedDate = DateTime.UtcNow };
            _context.Companies.Add(ex1);
            _context.SaveChanges();
        }
    }
}
