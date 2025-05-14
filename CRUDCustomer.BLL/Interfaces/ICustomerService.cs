using CRUDCustomer.Models.DTOs;
using CRUDCustomer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>>  GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerCreateResuestDto customerDto);
        Task UpdateCustomerAsync(int id, CustomerUpdateResuestDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
