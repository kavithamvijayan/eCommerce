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
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext context;

        public class PostResponse
        {
            public bool Success { get; set; }
            public int Id { get; set; }
        }
        public ReviewsController(AppDbContext appDbContext)
        {
            context = appDbContext;
            if (context.Reviews.Count() == 0)
            {
                context.Reviews.AddRange(new List<Reviews>
                {
                    new Reviews{ giftId=1,CustomerId=1,title="bad",body="cvbn",image="cfvgbh"},
                });
            }

        }
        // GET: api/Reviews
        [HttpGet]
        public ActionResult<List<Reviews>> Get()
        {
            return context.Reviews.ToList();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reviews>> Get(int id) => await context.Reviews.SingleOrDefaultAsync(o => o.Id == id);

        // POST: api/Reviews
        [HttpPost]
        public async Task<PostResponse> Post([FromBody] Reviews reviews)
        {
            var pr = new PostResponse()
            {
                Success = false,
                Id = 0
            };
            try
            {
                int UserId = int.Parse(HttpContext.Session.GetString("userId"));
                if (reviews.Id == UserId)
                {
                    await context.Reviews.AddAsync(reviews);
                    await context.SaveChangesAsync();
                    pr.Success = true;
                    pr.Id = reviews.Id;
                }
            }
            catch { }
            return pr;
        }
        public class PutResponse
        {
            public bool Success { get; set; }
        }
        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<PutResponse> Put(int id, [FromBody] Reviews reviews)
        {
            var pr = new PutResponse() { Success = false };

            try
            {
                if (reviews.Id > 0 && reviews.giftId > 0 && reviews.CustomerId > 0 && reviews.image.Length > 0 && reviews.title.Length > 0 && reviews.body.Length > 0)
                {
                    var oldReview = await context.Reviews.SingleOrDefaultAsync(s => s.Id == id);
                    if (oldReview != null)
                    {
                        oldReview.giftId = reviews.giftId;
                        oldReview.CustomerId = reviews.CustomerId;
                        oldReview.title = reviews.title;
                        oldReview.body = reviews.body;
                        oldReview.image = reviews.image;
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
                var oldS = await context.Reviews.SingleOrDefaultAsync(s => s.Id == id);
                if (oldS != null)
                {
                    context.Reviews.Remove(oldS);
                    await context.SaveChangesAsync();
                }
                dr.Success = true;
            }
            catch { }

            return dr;
        }
    }
}
