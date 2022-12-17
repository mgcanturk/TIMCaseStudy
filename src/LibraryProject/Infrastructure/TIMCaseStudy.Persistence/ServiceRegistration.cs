﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIMCaseStudy.Persistence.Context;

namespace TIMCaseStudy.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<TIMCaseStudyDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
