using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
    public class FieldQueryExpressionFactory
    {
     
        public static FieldQueryExpressionT<T> CreateFieldQueryExpression<T>(string fieldname,Func<T,T,bool> predict)
        {
            if(string.IsNullOrEmpty(fieldname) || predict==null)
            {
                throw new ArgumentNullException("The parameter can't be null!");
            }
            FieldQueryExpressionT<T> fieldQueryExpressionT = new FieldQueryExpressionT<T>();
            fieldQueryExpressionT.Result = DataType.BOOLNULL;
            fieldQueryExpressionT.Predict = predict;
            fieldQueryExpressionT.FieldName = fieldname;
            return fieldQueryExpressionT;

        }

    }
}
