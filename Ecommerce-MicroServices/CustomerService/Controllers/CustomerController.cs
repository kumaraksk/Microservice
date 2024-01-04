using CustomerService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private ApplicationDbContext _dbContext;
        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.customers);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            _dbContext.customers.Add(customer);
            _dbContext.SaveChanges();
            return Ok(customer);
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var entity = _dbContext.customers.FirstOrDefault(x => x.Id == Id);
            if (entity == null)
            {
                return NotFound();
            }
            _dbContext.customers.Remove(entity);
            _dbContext.SaveChanges();
            return Ok("Customer Deleted");
        }
    }
}