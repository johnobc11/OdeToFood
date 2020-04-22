using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OneToFood.Core;

namespace OdeToFood.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFood.Data.OdeToFoodFbContext _context;

        public IndexModel(OdeToFood.Data.OdeToFoodFbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
