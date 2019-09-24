using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericQueryLibrary
{
    public class DomainModel<T> : IModel<T>
    {
        public T ModelID { get; set; }

        public  bool IsOrExistsQueryFieldAttribute(string pname)
        {
            bool flag = false;
            PropertyInfo[] propertyInfos = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (null != propertyInfos && propertyInfos.Length > 0 && propertyInfos.Where(p => p.Name == pname).Count() > 0)
            {
                flag = true;
            }
            else if (null == propertyInfos || propertyInfos.Length > 0)
            {
                throw new Exception("The property of DomainModel can't be null!");
            }
            else
            {
                throw new Exception(string.Format("Canot find {0} QueryFieldAttribute.",pname));

            }
            return flag;
        }

        public PropertyInfo GetPropertyByName(string pname)
        {
            if(string.IsNullOrEmpty(pname)) throw new ArgumentNullException("The PropertyName can't be null!");
            PropertyInfo[] propertyInfos = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return propertyInfos.Where(p => p.Name == pname).FirstOrDefault();
        }

        public object GetPropertyValueByName(string pname)
        {
            if (string.IsNullOrEmpty(pname)) throw new ArgumentNullException("The PropertyName can't be null!");

            PropertyInfo propertyInfo = this.GetPropertyByName(pname);
            if(null==propertyInfo) throw new ArgumentNullException(string.Format("The {0} Property doesn't exist!", pname));

            return GetPropertyByName(pname).GetValue(this);
        }

        public void SetPropertyValue(string propertyName,object propertyValue)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("The PropertyName can't be null!");

            PropertyInfo domainPropertyInfo = GetPropertyByName(propertyName);
            if(null!=domainPropertyInfo)
            {

                if (null != propertyValue)
                {
                    domainPropertyInfo.SetValue(this, propertyValue);
                }
                else
                {
                    domainPropertyInfo.SetValue(this, GetPropertyDefaultValue(domainPropertyInfo));

                }

            }
            else
            {
                throw new Exception(string.Format("{0} Property doesn't exist!",propertyName));
            }
        }


        //Waiting For Test:
        public  bool QueryFieldIsOrNotDefaultValue(PropertyInfo propertyInfo)
        {
            bool flag = false;
            if (null == propertyInfo) throw new ArgumentNullException("PropertyInfo can't be null!");
            if (!IsOrExistsQueryFieldAttribute(propertyInfo.Name)) throw new Exception("The property of DomainModel can't be null!");
            object propertyInfoValue =GetPropertyValueByName(propertyInfo.Name);
            if (null == propertyInfoValue) flag = true;
            else
            {
                if (null == GetPropertyDefaultValue(propertyInfo)) flag = true;
                else
                {
                    if (propertyInfoValue.ToString() == GetPropertyDefaultValue(propertyInfo).ToString())
                    {
                        flag=true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
           
            }
     

            return flag;
        }


        private object GetPropertyDefaultValue(PropertyInfo propertyInfo)
        {
            Object propertyValue = null;

            if (propertyInfo.PropertyType == typeof(string))
            {
                propertyValue = DataType.STRING_EMPTY;

            }
            else if (propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Int16) || propertyInfo.PropertyType == typeof(Int32) || propertyInfo.PropertyType == typeof(Int64) || propertyInfo.PropertyType == typeof(float))
            {
                propertyValue = DataType.INT_ZERO;

            }
            else if (propertyInfo.PropertyType == typeof(DateTime))
            {
                propertyValue = DataType.NOW_DATETIME;

            }
            else if (propertyInfo.PropertyType == typeof(Guid))
            {
                propertyValue = DataType.GUID;
            }
            else if (propertyInfo.PropertyType == typeof(int?))
            {
                propertyValue = null;
            }
            return propertyValue;
        }

        public void SetPropertyValue(ViewModel<T> viewModel,PropertyInfo viewModelPropertyInfo,PropertyInfo domainModelPropertyInfo)
        {
            if (viewModelPropertyInfo.PropertyType != domainModelPropertyInfo.PropertyType)
            {
                throw new Exception("The PropertyType doesn't match!");
            }

            object viewPvalue=viewModel.GetPropertyValue(viewModelPropertyInfo);
            object domainPvalue=null;
            if (viewPvalue == null)
            {
                domainPvalue = null;
            }
            else
            {
                object viewModelPropertyDefaultValue = GetPropertyDefaultValue(viewModelPropertyInfo);
                if (null == viewModelPropertyDefaultValue) { domainPvalue = null; }

                else
                {
                    if (viewPvalue.ToString() == viewModelPropertyDefaultValue.ToString())
                    {
                        domainPvalue = viewModelPropertyDefaultValue;
                    }
                    else
                    {
                        domainPvalue = viewPvalue;
                    }
                }
            
            }

            domainModelPropertyInfo.SetValue(this, domainPvalue);


        }

        public bool IsOrNotPredict(PropertyInfo propertyInfo)
        {
            bool flag = false;
            Type propertyType = propertyInfo.PropertyType;
            Object propertyValue = propertyInfo.GetValue(this);
            if (propertyValue == null)
            {
                flag = true;
            }
            else
            {
                if (propertyInfo.PropertyType == typeof(string) && string.IsNullOrEmpty(propertyValue.ToString().Trim()))
                {
                    flag = true;
                }
                else if ((propertyInfo.PropertyType == typeof(int) || propertyInfo.PropertyType == typeof(Int16) || propertyInfo.PropertyType == typeof(Int32) || propertyInfo.PropertyType == typeof(Int64) || propertyInfo.PropertyType == typeof(float)) && propertyValue.ToString() == DataType.INT_ZERO.ToString())
                {
                    flag = true;
                }
                else if (propertyInfo.PropertyType == typeof(DateTime) && propertyValue.ToString() == DataType.NOW_DATETIME.ToString())
                {
                    flag = true;
                }
                else if (propertyInfo.PropertyType == typeof(Guid) && propertyValue.ToString() == DataType.GUID.ToString())
                {
                    flag = true;
                }
            }
         
            return flag;
        }

    }
}
