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
    public class IndexModel : PageModel
    {
        private readonly Project1.InventoryContext _context;

        public IndexModel(Project1.InventoryContext context)
        {
            _context = context;
        }

        public IList<InventoryItem> InventoryItems { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inventory != null)
            {
                InventoryItems = await _context.Inventory.ToListAsync();
            }
        }
    }
}
