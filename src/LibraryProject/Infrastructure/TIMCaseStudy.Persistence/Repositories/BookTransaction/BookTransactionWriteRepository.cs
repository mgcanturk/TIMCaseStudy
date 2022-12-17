using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Application.Repositories;
using TIMCaseStudy.Domain.Entities;
using TIMCaseStudy.Persistence.Context;

namespace TIMCaseStudy.Persistence.Repositories
{
    public class BookTransactionWriteRepository : WriteRepository<BookTransaction>, IBookTransactionWriteRepository
    {
        public BookTransactionWriteRepository(TIMCaseStudyDbContext context) : base(context)
        {
        }
    }
}
