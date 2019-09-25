using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericQueryLibrary;


namespace Test
{
    public class DomainModelBlog :DomainModel<string>
    {
        public Guid 标识 { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateDateTime { get; set; }

        public int Count { get; set; }
    }
}
