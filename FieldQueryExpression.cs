using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
    public abstract class FieldQueryExpression:QueryExpression
    {
        public string FieldName { get; set; }
        public bool ? Result { get; set; }

        public Type FieldType { get; set; }

        public FieldQueryExpression()
        {

        }

        public FieldQueryExpression(QueryExpression leftQueryExpression, QueryExpression rightQueryExpression) : base(leftQueryExpression, rightQueryExpression)
        {
            leftQueryExpression = rightQueryExpression = null;
            
        }

       

    }
}
