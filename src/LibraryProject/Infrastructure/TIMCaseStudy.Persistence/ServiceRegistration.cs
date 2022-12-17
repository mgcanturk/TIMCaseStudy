using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Application.Repositories;
using TIMCaseStudy.Persistence.Context;
using TIMCaseStudy.Persistence.Repositories;

namespace TIMCaseStudy.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TIMCaseStudyDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            services.AddScoped<IBookReadRepository, BookReadRepository>();
            services.AddScoped<IBookTransactionReadRepository, BookTransactionReadRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<IMemberReadRepository, MemberReadRepository>();

            services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
            services.AddScoped<IBookWriteRepository, BookWriteRepository>();
            services.AddScoped<IBookTransactionWriteRepository, BookTransactionWriteRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IMemberWriteRepository, MemberWriteRepository>();
        }
    }
}
