using System.Collections.Generic;
using LibApp.Interfaces;
using LibApp.Data;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType);
        }

        public Customer Get(int id) => _context.Customers.Find(id);

        public void Add(Customer item) => _context.Customers.Add(item);

        public void Remove(int id) => _context.Customers.Remove(Get(id));

        public void Update(Customer item) => _context.Customers.Update(item);
        public void Save() => _context.SaveChanges();
    }
}
