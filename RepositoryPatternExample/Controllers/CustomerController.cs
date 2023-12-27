using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternExample.Models;
using RepositoryPatternExample.Services.CustomerService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPatternExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{

    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerService _customerService;

    public CustomerController(ILogger<CustomerController> logger,
        ICustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> ListAll()
    {
        var customers = await _customerService.ListAll(); // Assuming ListAll() has an asynchronous counterpart ListAllAsync()

        if (customers != null)
        {
            return Ok(customers);
        }

        return NotFound(); // Return 404 Not Found if no customers are found
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetById(int id)
    {
        var customer = await _customerService.GetById(id);

        if (customer != null)
        {
            return Ok(customer);
        }

        return NotFound(); // Return 404 Not Found if no customers are found
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Add(Customer customer)
    {
        if (customer == null)
        {
            return BadRequest("Invalid customer data");
        }
        var result = await _customerService.Add(customer);
        if (result is null)
            return NotFound(); // Return 404 Not Found if no customers are found

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Customer?>> Update(int id, Customer request)
    {
        var result = await _customerService.Update(id, request);
        if (result is null)
            return NotFound(); // Return 404 Not Found if no customers are found

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Customer?>> Delete(int id)
    {
        var result = await _customerService.Delete(id);
        if (result is null)
            return NotFound(); // Return 404 Not Found if no customers are found

        return Ok(result);
    }
}


