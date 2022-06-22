using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using testcrud3.Data;
using testcrud3.Models;
using testcrud3.Repository;

namespace testcrud3.Pages.CRUD
{
    public class IndexModel : PageModel
    {
        private readonly testcrud3.Data.testcrud3Context _context;
        private readonly ITestDBRepository testdbrepository;

        public IndexModel(testcrud3.Data.testcrud3Context context, ITestDBRepository testdbrepository)
        {
            _context = context;
            this.testdbrepository = testdbrepository;
        }

        public IList<TestDb> TestDb { get;set; } = default!;

        public TestDb TestDb2 { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TestDb != null)
            {
                TestDb = await _context.TestDb.ToListAsync();
                //TestDb2 = await testdbrepository.GetAsync();
                //TestDb = (IList<TestDb>)await testdbrepository.GetAllAsync();
            }
        }
    }
}
