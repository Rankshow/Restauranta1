using Microsoft.AspNetCore.Mvc;
using Restauranta1.Infrastructure.Seeders;

namespace Restaurant1.Api.Controllers;

[Route("api/restaurants")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantSeeder _restaurantSeeder;

    public RestaurantController(IRestaurantSeeder restaurantSeeder)
    {
        _restaurantSeeder = restaurantSeeder;
    }

    [HttpGet]
    public IActionResult Get()
    {
       return Ok(_restaurantSeeder.Seed());
    }
}
