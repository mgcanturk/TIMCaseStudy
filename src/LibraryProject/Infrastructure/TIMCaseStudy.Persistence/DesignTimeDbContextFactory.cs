using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Persistence.Context;

namespace TIMCaseStudy.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TIMCaseStudyDbContext>
    {
        public TIMCaseStudyDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TIMCaseStudyDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
