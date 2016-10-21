using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinimumBid { get; set; } = 1;
        public List<Bid> Bids { get; set; }
        public int MaxBids { get; set; }
        public string PictureSource { get; set; }
    }
}
