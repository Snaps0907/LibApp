using System.Collections.Generic;
using LibApp.Models;

namespace LibApp.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer Get(int id);
        void Add(Customer item);
        void Remove(int id);
        void Update(Customer item);
        void Save();

    }
}
