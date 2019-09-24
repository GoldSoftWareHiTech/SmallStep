using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace GenericQueryLibrary
{
    internal class QueryExpressionComplier
    {
        public static FieldQueryExpressionCollections GetFieldExpressions(QueryExpression queryExpression)
        {
            FieldQueryExpressionCollections fes = new FieldQueryExpressionCollections();
            if (null == queryExpression) throw new ArgumentNullException("QueryExpression can't be null!");
            else
            {
                if (typeof(FieldQueryExpression) == queryExpression.GetType())
                {
                    //throw new Exception("The type of QueryExpression can't be FieldQueryExpression !");
                    GetFieldExpressionFromTree(queryExpression, fes);
                }
                else
                {
                    GetFieldExpressionFromTree(queryExpression, fes);
                }
            }
            return fes;

        }


        private static void GetFieldExpressionFromTree(QueryExpression queryExpression, FieldQueryExpressionCollections qfc)
        {

            if (null != queryExpression.LeftQueryExpression)
            {
                GetFieldExpressionFromTree(queryExpression.LeftQueryExpression, qfc);
                GetFieldExpressionFromTree(queryExpression.RightQueryExpression, qfc);
            }
            else
            {
                if (null == queryExpression.LeftQueryExpression) // && queryExpression.GetType() == typeof(FieldQueryExpression)
                {
                    qfc.AddFieldQueryExpressionAndResult((FieldQueryExpression)queryExpression, null);
                }

            }

        }

        private static Expression GenerateExpressionQueryTree(QueryExpression queryExpression)
        {
            Expression expressionTree = null;
            if (null == queryExpression) throw new ArgumentNullException("QueryExpression can't be null!");
            else
            {
              
                    if (null != queryExpression.LeftQueryExpression)
                    {

                        LogicalCalculationQueryExpression logicalCalculationQueryExpression = (LogicalCalculationQueryExpression)queryExpression;
                        if (logicalCalculationQueryExpression.Logicalcalculation == (int)LogicalCalculationEnum.And)
                        {

                            return Expression.And(GenerateExpressionQueryTree(queryExpression.LeftQueryExpression),GenerateExpressionQueryTree(queryExpression.RightQueryExpression));

                        }
                        else if (logicalCalculationQueryExpression.Logicalcalculation == (int)LogicalCalculationEnum.Or)
                        {
                            return Expression.Or(GenerateExpressionQueryTree(queryExpression.LeftQueryExpression), GenerateExpressionQueryTree(queryExpression.RightQueryExpression));

                        }


                    }
                    else
                    {
                        return Expression.Constant(((FieldQueryExpression)queryExpression).Result);

                    }
                
            }
            return expressionTree;


        }

        public static Expression<Func<bool>> GetLambdaExpresstionTree(QueryExpression queryExpression)
        {
            return Expression.Lambda<Func<bool>>(GenerateExpressionQueryTree(queryExpression));
        }

    }
}
