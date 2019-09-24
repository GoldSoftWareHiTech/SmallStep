using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GenericQueryLibrary
{
    internal class MappingModel<T>
    {
          
        public static DomainModel<T> ConvertViewModelToDataModel(ViewModel<T> viewModel,DomainModel<T> domainModel)
        {  
            //转换后的domainModel
            DomainModel<T> convertedDomainModel =domainModel;
            PropertyInfo[] propertyInfos =viewModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (null == viewModel || propertyInfos.Count()==0) throw new ArgumentNullException("ViewModel can't be null!");
            else
            {
                string pname = string.Empty; ;
                PropertyInfo domainPropertyInfo;

                if (!ReflectionUtility.IsOrNotExistQueryFieldAttribute(propertyInfos))
                {
                    throw new Exception("The QueryFieldAttribute on the ViewModel must be defined!");
                }
                
                foreach (PropertyInfo viewPropertyInfo in propertyInfos)
                {
                    if (ReflectionUtility.IsOrNotExistQueryFieldAttribute(viewPropertyInfo))
                    { 
                        //获取自定义属性FieldAttribute的名称
                        pname = ReflectionUtility.GetPropertyName(viewPropertyInfo);
                        if (!string.IsNullOrEmpty(pname))
                        {
                            //领域模型是否包含对应的属性名称
                            if (domainModel.IsOrExistsQueryFieldAttribute(pname))
                            {
                                domainPropertyInfo = domainModel.GetPropertyByName(pname);
                                domainModel.SetPropertyValue(viewModel,viewPropertyInfo, domainPropertyInfo);
                             
                            }
                        }
                        else
                        {
                            throw new ArgumentNullException(string.Format("The name of {0}  property of domainmodel can't be null!",pname));
                        }

                    }

                }

            }           
            return convertedDomainModel;
        }


    }
}
