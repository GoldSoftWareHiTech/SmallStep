using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericQueryLibrary
{
    public class ViewModel<T> : IModel<T>
    {
        public T ModelID { get; set; }

        public  Object GetPropertyValue( PropertyInfo propertyInfo)
        {
            object propertyValue = null;
            if (null == propertyInfo)
            {
               throw new ArgumentNullException("The propertyInfo can't be null!");
            }

            propertyValue = propertyInfo.GetValue(this);         
            return propertyValue;
        }


    }
}
