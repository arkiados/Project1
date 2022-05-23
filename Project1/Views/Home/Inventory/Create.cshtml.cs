using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project1;
using Project1.Models;

namespace Project1.Views.Home.Inventory
{
    public class CreateModel : PageModel
    {
        private readonly Project1.InventoryContext _context;

        public CreateModel(Project1.InventoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InventoryItem InventoryItems { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Inventory == null || InventoryItems == null)
            {
                return Page();
            }

            _context.Inventory.Add(InventoryItems);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
