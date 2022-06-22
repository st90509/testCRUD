﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using testcrud3.Data;
using testcrud3.Models;

namespace testcrud3.Pages.CRUD
{
    public class DeleteModel : PageModel
    {
        private readonly testcrud3.Data.testcrud3Context _context;

        public DeleteModel(testcrud3.Data.testcrud3Context context)
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

            var testdb = await _context.TestDb.FirstOrDefaultAsync(m => m.SystemInformationId == id);

            if (testdb == null)
            {
                return NotFound();
            }
            else 
            {
                TestDb = testdb;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(byte? id)
        {
            if (id == null || _context.TestDb == null)
            {
                return NotFound();
            }
            var testdb = await _context.TestDb.FindAsync(id);

            if (testdb != null)
            {
                TestDb = testdb;
                _context.TestDb.Remove(TestDb);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
