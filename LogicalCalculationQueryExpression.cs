using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
    public class LogicalCalculationQueryExpression : QueryExpression
    {
        private int _logicalCalculation;
        private LogicalCalculationEnum _logicalCalculationEnum;
        public LogicalCalculationQueryExpression(QueryExpression leftQueryExpression,QueryExpression rightQueryExpression,LogicalCalculationEnum logicalCalculationEnum) : base(leftQueryExpression, rightQueryExpression) //int logicalCalculation
        {
            if (null == leftQueryExpression || null == rightQueryExpression)
            {
                throw new ArgumentNullException("The leftQueryExpression and rightQueryExpression can't be null!");
            }
            this._logicalCalculationEnum = logicalCalculationEnum;
            this._logicalCalculation = (int)logicalCalculationEnum;
        }
        public int Logicalcalculation { get { return _logicalCalculation; } set { _logicalCalculation = value; } }

        public LogicalCalculationEnum LogicalCalculationEnum { get { return _logicalCalculationEnum; } set { _logicalCalculationEnum = value; } }


    }
}
