using AuctionApp.Data;
using AuctionApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Services
{
    public class ItemService
    {
        private IGenericRepository _repo;

        public ItemService(IGenericRepository repo)
        {
            this._repo = repo;
        }
        public ICollection<Item> ListItems()
        {
            return (from i in _repo.Query<Item>()
                    select i).ToList();
        }
        public ICollection<Item> ListItemsWithBids()
        {
            return (from i in _repo.Query<Item>()
                    .Include(i => i.Bids)
                    select i).ToList();
        }
        public Item GetItem(int id) {
            return (from i in _repo.Query<Item>()
                    .Include(i => i.Bids)
                    where i.Id == id
                    select i).FirstOrDefault();
        }
        public ICollection<Bid> ListBids()
        {
            return (from i in _repo.Query<Bid>()
                    select i).ToList();
        }

       
        public void AddBid(Bid bid)
        {
            var item = (from i in _repo.Query<Item>() //selected item
                            where i.Id == bid.ItemId select i).FirstOrDefault();
            var topBid = item.Bids.OrderBy((b) => b.Value).FirstOrDefault(); //finds top bid
            if (topBid == null || topBid.Value < bid.Value) //if there is no top bid
            {
                _repo.Add(bid); //add it
                _repo.SaveChanges();
            }
        }
    }
}
