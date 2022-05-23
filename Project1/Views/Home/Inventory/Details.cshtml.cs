using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project1;
using Project1.Models;

namespace Project1.Views.Home.Inventory
{
    public class DetailsModel : PageModel
    {
        private readonly Project1.InventoryContext _context;

        public DetailsModel(Project1.InventoryContext context)
        {
            _context = context;
        }

      public InventoryItem InventoryItems { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }

            var inventoryitems = await _context.Inventory.FirstOrDefaultAsync(m => m.ItemId == id);
            if (inventoryitems == null)
            {
                return NotFound();
            }
            else 
            {
                InventoryItems = inventoryitems;
            }
            return Page();
        }
    }
}
