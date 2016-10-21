using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        [JsonIgnore]
        public Item Item { get; set; }
        public int ItemId { get; set; }
    }
}
