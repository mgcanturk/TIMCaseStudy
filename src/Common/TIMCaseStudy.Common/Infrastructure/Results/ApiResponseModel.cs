using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMCaseStudy.Common.Infrastructure.Results
{
    public class ApiResponseModel
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsResult { get; set; }
        public object Result { get; set; }
    }
}
