using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testcrud3.Data;
using testcrud3.Models;

namespace testcrud3.Pages.CRUD
{
    public class EditModel : PageModel
    {
        private readonly testcrud3.Data.testcrud3Context _context;

        public EditModel(testcrud3.Data.testcrud3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public TestDb TestDb { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(byte? id)
        {
            if (id == null || _context.TestDb == null)
            {
                return NotFound();
            }

            var testdb =  await _context.TestDb.FirstOrDefaultAsync(m => m.SystemInformationId == id);
            if (testdb == null)
            {
                return NotFound();
            }
            TestDb = testdb;
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

            _context.Attach(TestDb).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestDbExists(TestDb.SystemInformationId))
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

        private bool TestDbExists(byte id)
        {
          return (_context.TestDb?.Any(e => e.SystemInformationId == id)).GetValueOrDefault();
        }
    }
}
