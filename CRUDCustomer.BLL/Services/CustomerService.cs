using CRUDCustomer.BLL.Interfaces;
using CRUDCustomer.DAL.Interfaces;
using CRUDCustomer.Models.DTOs;
using CRUDCustomer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomerAsync(CustomerCreateResuestDto customerDto)
        {
            Customer customer = new Customer()
            {
                CustomerName = customerDto.CustomerName,
                CustomerAddress = customerDto.CustomerAddress,
                CustomerCode = customerDto.CustomerCode,
                CreatedBy = customerDto.RequestBy,
                ModifiedBy = customerDto.RequestBy,

                CreatedAt = DateTime.Now,
                ModifiedAt  = DateTime.Now,

            };

           await _customerRepository.AddAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetAsync(id);
            if (customer == null) throw new KeyNotFoundException($"Customer with id {id} not found");
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();


            return customers.ToList();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetAsync(id);
            if (customer == null) throw new KeyNotFoundException($"Customer with id {id} not found");

            return customer;
        }

        public async Task UpdateCustomerAsync(int id, CustomerUpdateResuestDto customerDto)
        {
            var customer = await _customerRepository.GetAsync(id);

            if(customer == null) throw new KeyNotFoundException($"Customer with id {id} not found");
            

            customer.CustomerName = customerDto.CustomerName;
            customer.CustomerAddress = customerDto.CustomerAddress;
            customer.CustomerCode = customerDto.CustomerCode;
            customer.ModifiedBy = customerDto.RequestBy;
            customer.ModifiedAt = DateTime.Now;

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
