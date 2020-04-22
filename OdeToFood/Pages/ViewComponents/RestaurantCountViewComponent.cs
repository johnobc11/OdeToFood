using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Pages.ViewComponents
{
    public class RestaurantCountViewComponent
        :ViewComponent
    {
        private readonly RestaurantData restaurantData;

        public RestaurantCountViewComponent(RestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
