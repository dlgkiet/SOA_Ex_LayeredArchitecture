using Microsoft.EntityFrameworkCore;
using MyApp.Persistence;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddCustomer(Customer customer)
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Lỗi khi cập nhật dữ liệu: " + (ex.InnerException?.Message ?? ex.Message));
                throw;
            }
        }
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
