using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testcrud3.Models;

namespace testcrud3.Data
{
    public class testcrud3Context : DbContext
    {
        public testcrud3Context (DbContextOptions<testcrud3Context> options)
            : base(options)
        {
        }

        public DbSet<testcrud3.Models.TestDb>? TestDb { get; set; }
    }
}
