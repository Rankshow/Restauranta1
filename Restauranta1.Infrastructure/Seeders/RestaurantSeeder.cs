﻿using Restauranta1.Domain.Entities;
using Restauranta1.Infrastructure.Persistence;

namespace Restauranta1.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }


    }
    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants =
        [
            new()
            {
                Name = "Kfc",
                Category = "Fast Food",
                Description = "Kfc (short for Kentucky fried chicken) is an American fast food restsaurant chain headquarter",
                ContactEmail = "contact@gmail.com",
                HasDelivery = true,
                Dishes =
                [
                    new ()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10 pcs)",
                        Price = 10.30M
                    },
                    new ()
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken Nuggets (5 pcs)",
                        Price = 5.30M,
                    },
                ],
                Address = new Address()
                {
                    City = "London",
                    Street = "Cork St 5",
                    PostalCode = "WC2N 5DU"
                }
            },
            new ()
                {
                    Name = "McDonald Szewska",
                    Category = "Fast Food",
                    Description = "MCDonald's Corporation (McDonald's) incorporated on December 21 1964, operates and fried chicken",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    Address = new Address()
                    {
                        City = "London",
                        Street = "Boots 193",
                        PostalCode = "W1F 8SR",
                    }
                }
        ];

        return restaurants;
    }
}
