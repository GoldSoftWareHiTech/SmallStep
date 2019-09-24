using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
    public class QueryFieldAttribute:Attribute
    {

        public QueryFieldAttribute(string fieldname)
        {
            if (string.IsNullOrEmpty(fieldname))
                throw new ArgumentNullException("QueryFieldAttribute can't be null!");
            _fieldname = fieldname;
        }
        public string FieldName => _fieldname;


        protected string _fieldname;


    }
}
