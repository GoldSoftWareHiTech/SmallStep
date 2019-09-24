using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
    public class LogicalCalculationExpressionFactory
    {
        public static LogicalCalculationQueryExpression CreateLogicalCalculationQueryExpression(QueryExpression left,QueryExpression right,LogicalCalculationEnum logicalCalculationEnum)
        {
        
            LogicalCalculationQueryExpression logicalCalculationQueryExpression = new LogicalCalculationQueryExpression(left,right,logicalCalculationEnum);
            return logicalCalculationQueryExpression;

        }

        public static  LogicalCalculationQueryExpression CreateEmptyLogicalCalculationQueryExpression()
        {
            return CreateLogicalCalculationQueryExpression(null, null,LogicalCalculationEnum.And);
        }

    }
}
