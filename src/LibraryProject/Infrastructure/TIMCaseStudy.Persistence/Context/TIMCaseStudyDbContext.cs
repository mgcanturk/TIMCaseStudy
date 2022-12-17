using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Domain.Entities;

namespace TIMCaseStudy.Persistence.Context
{
    public class TIMCaseStudyDbContext : DbContext
    {
        public TIMCaseStudyDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookTransaction> BookTransactions { get; set; }
    }
}
