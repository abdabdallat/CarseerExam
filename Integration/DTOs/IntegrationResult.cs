using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.DTOs
{
    public class IntegrationResult<T>
    {
        public long Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public T Results { get; set; }
    }
}
