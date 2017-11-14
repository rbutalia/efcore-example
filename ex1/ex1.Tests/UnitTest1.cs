using ex1.Data;
using ex1.Domain;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ex1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_Existing_Companies()
        {
            
            var context = new Ex1DataContext(_options);
            var repo = new DisconnectedData(context);
            Assert.IsTrue(repo.GetCompanyReferenceList().Count > 0);
            

        }
        
        private DbContextOptions<Ex1DataContext> _options;

        public UnitTest1()
        {
            string dbName = "CompaniesDB";
            _options = new DbContextOptionsBuilder<Ex1DataContext>().UseInMemoryDatabase(databaseName: dbName).Options;
            SeedInMemoryStore(dbName);
        }



        private void SeedInMemoryStore(string dbName)
        {
            using (var context = new Ex1DataContext(_options))
            {
                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(
                      new Company
                      {
                          CompanyID = 1,
                          CompanyName = "Randeep Company 1",

                          Orders = new List<Order>
                                 {
                                     new Order {CompanyID = 1},
                                     new Order {CompanyID = 1}
                                 }
                      },
                      new Company
                      {
                          CompanyID = 2,
                          CompanyName = "Randeep Company 2",

                          Orders = new List<Order>
                                 {
                                     new Order { CompanyID = 2 },
                                     new Order { CompanyID = 2 }
                                 }
                      });
                    context.SaveChanges();
                }
            }
        }

    }


}
