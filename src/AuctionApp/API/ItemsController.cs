using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Services;
using AuctionApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AuctionApp.API
{
    [Route("api/[controller]")]
    public class ItemsController : Controller
    {
        private ItemService itemService;

        public ItemsController(ItemService itemService)
        {
            this.itemService = itemService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return itemService.ListItems();
        }

        [HttpGet("withBids")]
        public IEnumerable<Item> GetWithBids()
        {
            return itemService.ListItemsWithBids();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return itemService.GetItem(id);

        }

        // POST api/values
        [HttpPost("addBid")]
        public void Post([FromBody] Bid bid)
        {
            itemService.AddBid(bid);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
