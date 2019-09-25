using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericQueryLibrary;


namespace Test
{
    public class ViewModelBlog :ViewModel<string>
    {
        [QueryField("标识")]
        public Guid ID { get; set; }

        [QueryField("Title")]
        public string  标题{ get; set; }

        //[QueryField("Content")]
        public string Content { get; set; }

        [QueryField("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }


        [QueryField("Count")]
        public int Count { get; set; }


    }
}
