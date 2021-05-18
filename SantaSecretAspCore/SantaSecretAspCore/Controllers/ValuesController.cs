using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SantaSecretAspCore.Models;
using Microsoft.EntityFrameworkCore;

namespace SantaSecretAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext context;

        public class PostResponse
        {
            public bool Success { get; set; }
            public int Id { get; set; }
        }

        public ValuesController(AppDbContext appDbContext)
        {
            context = appDbContext;
            if (context.Gifts.Count() == 0)
            {
                context.Gifts.AddRange(new List<Gifts>
                {
                    new Gifts{ name="value1",price=30,image="a.jpeg",desc="xmas",shippingCost=10},
                    new Gifts{ name="value2",price=30,image="a.jpeg",desc="xmas",shippingCost=10},
                   // new ObjectToSend {Data1 = "value1",Data2 ="value2"},
                    //new ObjectToSend {Data1 = "value3",Data2 ="value4"},
                });
            }

        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<Gifts>> Get()
        {
            return context.Gifts.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gifts>> Get(int id) => await context.Gifts.SingleOrDefaultAsync(o => o.Id == id);

        // POST api/values
        [HttpPost]
        public async Task<PostResponse> Post([FromBody] Gifts gifts)
        {
            var pr = new PostResponse()
            {
                Success = false,
                Id = 0
            };
            try
            {
                await context.Gifts.AddAsync(gifts);
                await context.SaveChangesAsync();
                pr.Success = true;
                pr.Id = gifts.Id;
            } catch { }
            return pr;
        }
        public class PutResponse
        {
            public bool Success { get; set; }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<PutResponse> Put(int id, [FromBody] Gifts gifts)
        {
            var pr = new PutResponse() { Success = false };

            try
            {
                if (gifts.Id > 0 && gifts.name.Length > 0&& gifts.price >0 &&gifts.image.Length>0 && gifts.shippingCost>0 &&gifts.desc.Length>0)
                {
                    var oldGift = await context.Gifts.SingleOrDefaultAsync(s => s.Id == id);
                    if (oldGift != null)
                    {
                        oldGift.name = gifts.name;
                        oldGift.price = gifts.price;
                        oldGift.image = gifts.image;
                        oldGift.desc = gifts.desc;
                        oldGift.shippingCost = gifts.shippingCost;
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
                var oldS = await context.Gifts.SingleOrDefaultAsync(s => s.Id == id);
                if (oldS != null)
                {
                    context.Gifts.Remove(oldS);
                    await context.SaveChangesAsync();
                }
                dr.Success = true;
            }
            catch { }

            return dr;
        }
    }
}
