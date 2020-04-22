using OneToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryResturantData : RestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryResturantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name="Jamie Italian", Location="Cardiff Bay", Cuisine=CuisineType.Italian},
                new Restaurant{Id = 2, Name="Nandos", Location="St Mary Street", Cuisine=CuisineType.Mexican},
                new Restaurant{Id = 3, Name="Hanoi", Location="Royal Arcade", Cuisine=CuisineType.Vietnamese}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        //method reserve for using datasources
        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null) => from r in restaurants
                                                                             where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                                                                             orderby r.Name
                                                                             select r;

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;

        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
