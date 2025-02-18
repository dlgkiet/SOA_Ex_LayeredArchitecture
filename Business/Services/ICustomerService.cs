using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetAllCustomers();
    }
}
