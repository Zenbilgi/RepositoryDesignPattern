namespace RepositoryPatternExample.Services.CustomerService
{
	public interface ICustomerService
	{
        Task<IEnumerable<Customer>> ListAll();

        Task<Customer?> GetById(int id);

        Task<Customer> Add(Customer customer);

        Task<Customer?> Update(int id, Customer request);

        Task<Customer?> Delete(int id);
    }
}

