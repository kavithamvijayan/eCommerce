using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SantaSecretAspCore.Models;
// Controller for Cusomer
namespace SantaSecretAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext context;

        public class PostResponse
        {
            public bool Success { get; set; }
            public int Id { get; set; }
        }
        public CustomerController(AppDbContext appDbContext)
        {
            context = appDbContext;
            if (context.Customer.Count() == 0)
            {
                context.Customer.AddRange(new List<Customer>
                {
                    new Customer{ name="Amrit",email="amrit@gmail.com", password="admin123",address="200 old carriage drive"},
                    new Customer{ name="Negin",email="negin@gmail.com", password="admin123",address="200 old carriage drive"},
                   // new ObjectToSend {Data1 = "value1",Data2 ="value2"},
                    //new ObjectToSend {Data1 = "value3",Data2 ="value4"},
                });
            }

        }
        // GET: api/Customer
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return context.Customer.ToList();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id) => await context.Customer.SingleOrDefaultAsync(o => o.Id == id);
         

        // POST: api/Customer
        [HttpPost]
        public async Task<PostResponse> Post([FromBody] Customer customer)
        {
            var pr = new PostResponse()
            {
                Success = false,
                Id = 0
            };
            try
            {
                await context.Customer.AddAsync(customer);
                await context.SaveChangesAsync();
                pr.Success = true;
                pr.Id = customer.Id;
            }
            catch { }
            return pr;
        }
        public class PutResponse
        {
            public bool Success { get; set; }
        }
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<PutResponse> Put(int id, [FromBody] Customer customer)
        {
            var pr = new PutResponse() { Success = false };

            try
            {
                if (customer.Id > 0 && customer.name.Length > 0 && customer.email.Length > 0 && customer.address.Length > 0 && customer.password.Length > 0 )
                {
                    var oldCustomer = await context.Customer.SingleOrDefaultAsync(s => s.Id == id);
                    if (oldCustomer != null)
                    {
                        oldCustomer.name = customer.name;
                        oldCustomer.email = customer.email;
                        oldCustomer.password = customer.password;
                        oldCustomer.address = customer.address;
                        await context.SaveChangesAsync();
                        pr.Success = true;
                    }
                }
            }
            catch { }

            return pr;
        }

        public class DeleteResponse
        {
            public bool Success { get; set; }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DeleteResponse> Delete(int id)
        {
            var dr = new DeleteResponse() { Success = false };

            try
            {
                var oldS = await context.Customer.SingleOrDefaultAsync(s => s.Id == id);
                if (oldS != null)
                {
                    context.Customer.Remove(oldS);
                    await context.SaveChangesAsync();
                }
                dr.Success = true;
            }
            catch { }

            return dr;
        }
    }
}
