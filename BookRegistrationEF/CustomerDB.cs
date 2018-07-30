using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
    static class CustomerDB
    {
        public static List<Customer> GetAllCustomer()
        {
            BkRegDBContext context = new BkRegDBContext();
            List<Customer> customers = context.Customer.ToList();
            return customers;
        }

        public static void Add(Customer c )
        {
            BkRegDBContext context = new BkRegDBContext();
            // assume is valid
            context.Customer.Add(c);
            context.SaveChanges();
        }
       
    }
}
