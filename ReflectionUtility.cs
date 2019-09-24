using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace GenericQueryLibrary
{
    public class ReflectionUtility
    {
        public static bool IsOrNotExistQueryFieldAttribute(PropertyInfo[] propertyInfos)
        {

            bool flag = true;
            if (null == propertyInfos || propertyInfos.Length == 0)
            {
                throw new ArgumentNullException("The PropertyInfo array cann't be null!");
            }
            else
            {
                var propertiesWithAttribute = propertyInfos.Where(t => Attribute.IsDefined(t, typeof(QueryFieldAttribute)));
                if (null == propertiesWithAttribute || propertiesWithAttribute.Count() == 0)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }

            return flag;
        }


        public static bool IsOrNotExistQueryFieldAttribute(PropertyInfo propertyInfo)
        {
            bool flag = true;
            if (null == propertyInfo)
            {
                throw new ArgumentNullException("The PropertyInfo  cann't be null!");
            }
            else
            {
                flag = Attribute.IsDefined(propertyInfo, typeof(QueryFieldAttribute));
            }
            return flag;
        }

        public static string GetPropertyName(PropertyInfo propertyInfo)
        {
            string pname = string.Empty;
            QueryFieldAttribute queryFieldAttribute = propertyInfo.GetCustomAttribute(typeof(QueryFieldAttribute)) as QueryFieldAttribute;
            pname = queryFieldAttribute.FieldName.ToString().Trim();
            return pname;
        }

 

    }
}
