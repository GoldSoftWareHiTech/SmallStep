using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GenericQueryLibrary
{
    public abstract class QueryExpression:ICloneable
    {
        private QueryExpression _leftQueryExpression;
        private QueryExpression _rightQueryExpression;
        //private static FieldQueryExpressionCollections _fes = new FieldQueryExpressionCollections();

        public QueryExpression()
        {

        }

        public QueryExpression(QueryExpression leftQueryExpression, QueryExpression rightQueryExpression)
        {
            _leftQueryExpression = leftQueryExpression;
            _rightQueryExpression = rightQueryExpression;
        }

     
        public QueryExpression LeftQueryExpression
        {
            get { return _leftQueryExpression; }
            set { _leftQueryExpression = value; }
        }

        public QueryExpression RightQueryExpression
        {
            get { return _rightQueryExpression; }
            set { _rightQueryExpression = value; }
        }

        //public FieldQueryExpressionCollections FieldQueryExpressions { get { return _fes; } }

        public static QueryExpression Add(QueryExpression left, QueryExpression right)
        {
            return LogicalCalculation(left,right,LogicalCalculationEnum.And);
        }

        public static QueryExpression Or(QueryExpression left, QueryExpression right)
        {
            return LogicalCalculation(left, right,LogicalCalculationEnum.Or);
        }

        private static QueryExpression LogicalCalculation(QueryExpression left, QueryExpression right,LogicalCalculationEnum logicalCalculationEnum)
        {
            QueryExpression queryExpression = null;
            if (logicalCalculationEnum == LogicalCalculationEnum.And)
            {
                queryExpression = new LogicalCalculationQueryExpression(left, right,LogicalCalculationEnum.And);
                
            }
            else if (logicalCalculationEnum == LogicalCalculationEnum.Or)
            {
                queryExpression = new LogicalCalculationQueryExpression(left, right,LogicalCalculationEnum.Or);
            }

            return queryExpression;
        }

        protected virtual object CloneNode() {
            return this.MemberwiseClone();
        }



        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
