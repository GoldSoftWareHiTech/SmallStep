using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
    public class FieldQueryExpressionT<T> : FieldQueryExpression
    {

        public Func<T, T, bool> Predict { get; set; }

        public FieldQueryExpressionT()
        {

        }

        public FieldQueryExpressionT(QueryExpression leftQueryExpression=null, QueryExpression rightQueryExpression=null) : base(leftQueryExpression, rightQueryExpression)
        {
            

        }


        public bool CalculateResult(T t1,T t2)
        {
            this.Result= Predict(t1, t2);
            return Predict(t1, t2);
        }


    }
}
