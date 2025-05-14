using CRUDCustomer.DAL.Interfaces;
using CRUDCustomer.DataAccess;
using CRUDCustomer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private readonly AppDbContext _db;
        public CustomerRepository(AppDbContext appDbContext) 
        {
            _db = appDbContext;
        }
        public async Task AddAsync(Customer customer)
        {
           await _db.Customer.AddAsync(customer);
           await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _db.Customer.FindAsync(id);

            if(customer != null)
            {
                _db.Customer.Remove(customer);
                await _db.SaveChangesAsync();
            }

        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _db.Customer.ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await _db.Customer.FindAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
           _db.Customer.Update(customer);
            await _db.SaveChangesAsync();
        }
    }
}
