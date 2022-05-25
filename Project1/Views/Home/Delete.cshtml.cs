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
    public class DeleteModel : PageModel
    {
        private readonly Project1.InventoryContext _context;

        public DeleteModel(Project1.InventoryContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inventory == null)
            {
                return NotFound();
            }
            var inventoryitems = await _context.Inventory.FindAsync(id);

            if (inventoryitems != null)
            {
                InventoryItems = inventoryitems;
                _context.Inventory.Remove(InventoryItems);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
