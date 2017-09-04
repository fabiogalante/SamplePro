using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePro.Models
{
    public class Category : EntityBase
    {
        public string CategoryName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
