using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using Dapper;
using testcrud3.Models;
using testcrud3.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testcrud3.Repository
{
    public class TestDBRepository : BaseRepository<TestDb>, ITestDBRepository
    {
        private readonly ScaffoldContext ScaffoldContext;
        public TestDBRepository(ScaffoldContext ScaffoldContext) : base(ScaffoldContext)
        {
            this.ScaffoldContext = ScaffoldContext;
        }
    }
       
    public interface ITestDBRepository : IBaseRepository<TestDb> { }
}
