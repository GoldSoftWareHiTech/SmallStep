using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Reposity
    {


        public static IEnumerable<DomainModelBlog> GetBlogs(Func<DomainModelBlog,DomainModelBlog,bool> func,DomainModelBlog domainModelBlog)
        {

            List<DomainModelBlog> domainModelBlogs = new List<DomainModelBlog>() { new DomainModelBlog() { Title = "Matrix", Content = "Matrix", Count = 1, CreateDateTime = DateTime.Now }, new DomainModelBlog() { Title = "Linq", Content = "Linq", Count = 1, CreateDateTime = DateTime.Now } };

            List<DomainModelBlog> predictDomainModelBlogs = new List<DomainModelBlog>();
            foreach(DomainModelBlog dblog in domainModelBlogs)
            {

                if(func(dblog, domainModelBlog))
                {

                    predictDomainModelBlogs.Add(dblog);

                }


            }
            return predictDomainModelBlogs;
        }

    }
}
