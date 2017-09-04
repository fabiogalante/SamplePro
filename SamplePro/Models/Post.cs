using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePro.Models
{
    public class Post : EntityBase

    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string PostImage { get; set; }
        public virtual Category Categories { get; set; }


    }
}
