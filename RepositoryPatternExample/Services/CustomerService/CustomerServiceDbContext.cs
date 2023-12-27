using Azure.Core;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternExample.Data;

namespace RepositoryPatternExample.Services.CustomerService
{
    public class CustomerServiceDbContext : ICustomerService
    {
        private readonly DataContext _dataContext;

		public CustomerServiceDbContext(DataContext dataContext)
		{
            _dataContext = dataContext;
		}

        public DataContext Get_dataContext()
        {
            return _dataContext;
        }

        public async Task<IEnumerable<Customer>> ListAll()
        {
            var customers = await _dataContext.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer?> GetById(int id)
        {
            var customer = await _dataContext.Customers.FindAsync(id);
            if (customer is null)
                return null;

            return customer;
        }

        public async Task<Customer> Add(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            await _dataContext.SaveChangesAsync();

            // Reload the customer from the database to get any generated values (e.g., ID)
            await _dataContext.Entry(customer).ReloadAsync();

            return customer;
        }

        public async Task<Customer?> Update(int id, Customer request)
        {
            var customer = await _dataContext.Customers.FindAsync(id);

            if (customer is null)
                return null;

            customer.Name = request.Name;
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Place = request.Place;

            await _dataContext.SaveChangesAsync();

            //await _dataContext.Entry(customer).ReloadAsync();

            return customer;
        }

        public async Task<Customer?> Delete(int id)
        {
            var customer = await _dataContext.Customers.FindAsync(id);

            if (customer is null)
                return null;

            _dataContext.Customers.Remove(customer);

            await _dataContext.SaveChangesAsync();

            //await _dataContext.Entry(customer).ReloadAsync();

            return customer;
        }


    }
}

