using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using testcrud3.Data;
using testcrud3.Models;
using testcrud3.Repository;

namespace testcrud3.Pages.CRUD
{
    public class CreateModel : PageModel
    {
        private readonly testcrud3.Data.testcrud3Context _context;
        private readonly ITestDBRepository testdbrepository;


        public CreateModel(testcrud3.Data.testcrud3Context context, ITestDBRepository testdbrepository)
        {
            _context = context;
            this.testdbrepository = testdbrepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TestDb TestDb { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TestDb == null || TestDb == null)
            {
                return Page();
            }

            _context.TestDb.Add(TestDb);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        //public async Task InsertAsync()
        //{
        //    await testdbrepository.InsertAsync(new TestDb()
        //    {
        //        SystemInformationId = (byte)123,
        //        DatabaseVersion = DateTime.Now.ToString(),
        //        ModifiedDate = DateTime.Now,
        //    });
        //    await this._context.SaveChangesAsync();
        //}
    }
}
