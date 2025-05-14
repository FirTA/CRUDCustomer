using CRUDCustomer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.DAL.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetAsync(int id);
        Task AddAsync(Customer customer);
        Task DeleteAsync(int id);
        Task UpdateAsync(Customer customer);
    }
}
