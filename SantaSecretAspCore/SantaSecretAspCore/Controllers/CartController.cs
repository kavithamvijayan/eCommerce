using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SantaSecretAspCore.Models;

namespace SantaSecretAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext context;

        public class PostResponse
        {
            public bool Success { get; set; }
            public int Id { get; set; }
        }
        public CartController(AppDbContext appDbContext)
        {
            context = appDbContext;
            if (context.Cart.Count() == 0)
            {
                context.Cart.AddRange(new List<Cart>
                {
                    new Cart{ giftId=1,customerId=1,quantity=10},
                    new Cart{ giftId=2,customerId=1,quantity=5},
                });
            }

        }
        // GET: api/Cart
        [HttpGet]
        public ActionResult<List<Cart>> Get()
        {
            return context.Cart.ToList();
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> Get(int id) => await context.Cart.SingleOrDefaultAsync(o => o.Id == id);


        // POST: api/Cart
        [HttpPost]
        public async Task<PostResponse> Post([FromBody] Cart cart)
        {
            var pr = new PostResponse()
            {
                Success = false,
                Id = 0
            };
            try
            {
                await context.Cart.AddAsync(cart);
                await context.SaveChangesAsync();
                pr.Success = true;
                pr.Id = cart.Id;
            }
            catch { }
            return pr;
        }
        public class PutResponse
        {
            public bool Success { get; set; }
        }
        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public async Task<PutResponse> Put(int id, [FromBody] Cart cart)
        {
            var pr = new PutResponse() { Success = false };

            try
            {
                if (cart.Id > 0 && cart.giftId > 0 && cart.customerId > 0 && cart.quantity > 0)
                {
                    var oldCart = await context.Cart.SingleOrDefaultAsync(s => s.Id == id);
                    if (oldCart != null)
                    {
                        oldCart.giftId = cart.giftId;
                        oldCart.customerId = cart.customerId;
                        oldCart.quantity = cart.quantity;
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
                var oldS = await context.Cart.SingleOrDefaultAsync(s => s.Id == id);
                if (oldS != null)
                {
                    context.Cart.Remove(oldS);
                    await context.SaveChangesAsync();
                }
                dr.Success = true;
            }
            catch { }

            return dr;
        }
    }
}
