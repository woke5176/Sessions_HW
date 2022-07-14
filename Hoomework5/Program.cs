using EFCoreScaffolding.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace EFCoreScaffolding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json");

            var config = configuration.Build();

            var connectionString = config.GetConnectionString("NorthwindDbConnection");

            var options = new DbContextOptionsBuilder<NorthwindContext>()
                                //.UseLazyLoadingProxies()
                                .UseSqlServer(connectionString)
                                .Options;

            var dbContext = new NorthwindContext(options);

            var customer = dbContext.Customers.Include(c => c.Orders).FirstOrDefault();
            var userID = 1;


            var emp = dbContext.Employees.Include(a => a.Territories).Where(e => e.EmployeeId == userID);

            foreach (var e in emp)
            {
                foreach (var x in e.Territories)
                {
                    Console.WriteLine(x.TerritoryDescription);
                }
            }

        
            var employee_max_sales = dbContext.Employees.Include(a => (a.Orders).GroupBy(o => o.EmployeeId).Count());

            employee_max_sales = employee_max_sales.Include(a => a.OrderDetail);

            // query 3 


            var prod = dbContext.Invoices.Select(x => new
            {
                productname
                = x.ProductName,
                ship_con = x.ShipCountry

            }).ToList();
            foreach(var x in prod)
            {
                Console.WriteLine(x.productname + " " + x.ship_con);

            }

            // query 4 

            var det = dbContext.Products.Include(o => o.OrderDetails).Select(x=> new
            {
                productname = x.ProductName,
                sales = x.UnitPrice * o.Quantity-object.Discount)

            });
         foreach(var d in det){
            Console.WriteLine(d.productname + " " + d.sales);
            }

           

           


        }
    }
}
