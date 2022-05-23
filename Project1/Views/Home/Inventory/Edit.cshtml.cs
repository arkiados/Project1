using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1;
using Project1.Models;

namespace Project1.Views.Home.Inventory
{
    public class EditModel : PageModel
    {
        private readonly Project1.InventoryContext _context;

        public EditModel(Project1.InventoryContext context)
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

            var inventoryitems =  await _context.Inventory.FirstOrDefaultAsync(m => m.ItemId == id);
            if (inventoryitems == null)
            {
                return NotFound();
            }
            InventoryItems = inventoryitems;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InventoryItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryItemsExists(InventoryItems.ItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InventoryItemsExists(int id)
        {
          return (_context.Inventory?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
