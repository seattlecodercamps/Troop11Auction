using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AuctionApp.Models;

namespace AuctionApp.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            ApplicationDbContext db = serviceProvider.GetService<ApplicationDbContext>();
            await db.Database.EnsureCreatedAsync();

            if (!db.Items.Any())
            {
                db.Items.AddRange(
                        new Item
                        {
                            Name = "Paris Hiltons Used Napkin",
                            Description = "Found in In-n-Out Burger Trash Can",
                            MinimumBid = 5.50m,
                            MaxBids = 10,
                            PictureSource = "/images/Napkin.jpg",
                            Bids = new List<Bid> {
                                new Bid {Value= 10.50m }
                            }
                        },
                        new Item
                        {
                            Name = "Priceless Chinese Terra Cotta Vase",
                            Description = "Butler Included",
                            MinimumBid = 999.99m,
                            MaxBids = 100,
                            PictureSource ="/images/TerraCotta.jpg",
                            Bids = new List<Bid> {
                                new Bid {Value= 999.99m },
                                new Bid {Value= 1000.01m }
                            }
                        },
                        new Item
                        {
                            Name = "Famous KFC Fried Rat",
                            Description = "World Renowned Sewer-y Flavor with Kernals Secret 11 Herbs and Spices. Extra Crunchy",
                            MinimumBid = 100.00m,
                            MaxBids = 10,
                            PictureSource = "/images/KFC-fried-rat.jpg",
                            Bids = new List<Bid> {
                                new Bid {Value= 100.00m }
                            }
                        }

                    );
            }
            db.SaveChanges();
        }
    }
}
