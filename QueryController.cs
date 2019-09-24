using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;

namespace GenericQueryLibrary
{
    public class QueryController
    {
        public IEnumerable<DomainModel<T>> GetDomainModels<T>(QueryExpression queryExpression, ViewModel<T> viewModel,DomainModel<T> domainModel, Func< Func<DomainModel<T>,DomainModel<T>,bool>, DomainModel<T>, IEnumerable<DomainModel<T>> > domainModelsFunc)
        {
            if (null == queryExpression || domainModelsFunc == null || viewModel==null || domainModelsFunc==null) throw new ArgumentNullException("The parameter can't be null!");

            //Firstly,we should convert the viewmodel to domainmodel
            DomainModel<T> convertedDomainModel = MappingModel<T>.ConvertViewModelToDataModel(viewModel, domainModel);
            if (null == domainModel) throw new Exception("DomainModel can't be null!");

            return domainModelsFunc(
                //m:要匹配的领域模型，也就是从Reposity层中获取的数据模型，经转换后的领域模型
                //n:被匹配的领域模型，也就是从View层中获取的视图模型，经转换后的领域模型
                (m, n) => {
                    
                    bool flag = false;
                    //Clone QueryExpression
                    QueryExpression cloneQueryExpression = cloneQueryExpression = queryExpression.Clone() as QueryExpression; //LogicalCalculationExpressionFactory.CreateEmptyLogicalCalculationQueryExpression();


                    //Get the FieldQueryExpresstion
                    //We should set another FieldQueryExpressionCollections named fieldQueryExpressionCollections_lambda because of modifying the keys
                    FieldQueryExpressionCollections fieldQueryExpressionCollections = QueryExpressionComplier.GetFieldExpressions(cloneQueryExpression);
                    //Error 0
                    FieldQueryExpressionCollections fieldQueryExpressionCollections_lambda = QueryExpressionComplier.GetFieldExpressions(cloneQueryExpression);



                    if (null != fieldQueryExpressionCollections && fieldQueryExpressionCollections.Count() > 0)
                    {                      
                        string pname = string.Empty;
                        FieldQueryExpression fieldQueryExpression = null;
                        PropertyInfo p, comparedp;
                        Type fieldQueryExpressionTType;
                        Object reflectedFieldQueryExpresstionT;

                        #region Foreach FieldQueryExpressionCollections
                        foreach (KeyValuePair<FieldQueryExpression,bool ?> kv in fieldQueryExpressionCollections)
                        {
                            //Step1:Reflect Model's property
                            fieldQueryExpression = kv.Key;
                            pname = fieldQueryExpression.FieldName;
                            p = m.GetPropertyByName(pname);
                            comparedp = n.GetPropertyByName(pname);
                            fieldQueryExpressionTType = typeof(FieldQueryExpressionT<>);
                            fieldQueryExpressionTType = fieldQueryExpressionTType.MakeGenericType(comparedp.PropertyType);
                            
                            //Error1
                            reflectedFieldQueryExpresstionT = Activator.CreateInstance(fieldQueryExpressionTType);

                            reflectedFieldQueryExpresstionT = fieldQueryExpression;

                            //Step2:Use Metadata and Func to Comapre model
                            if (n.IsOrNotPredict(comparedp))
                            {

                                //fieldQueryExpressionCollections.SetFieldQueryExpressionResultTrue(fieldQueryExpression);
                                fieldQueryExpressionCollections_lambda.SetFieldQueryExpressionResultTrue(fieldQueryExpression);
                            }
                            else
                            {
                                MethodInfo predictMethod = reflectedFieldQueryExpresstionT.GetType().GetMethod("CalculateResult");
                                object pv1 = m.GetPropertyValueByName(pname);
                                object pv2 = n.GetPropertyValueByName(pname);
                                
                                //Error2
                                bool result= (bool)(predictMethod.Invoke(reflectedFieldQueryExpresstionT, new Object[] { pv1, pv2 }));

                                //Error3
                                //fieldQueryExpressionCollections.SetFieldQueryExpressionResult(fieldQueryExpression, result);
                                fieldQueryExpressionCollections_lambda.SetFieldQueryExpressionResult(fieldQueryExpression, result);

                            }
                          
                        }
                        #endregion

                        #region Generate LambdaExpression Tree and calculate the result dynamicly.
                        Func<bool> func = QueryExpressionComplier.GetLambdaExpresstionTree(cloneQueryExpression).Compile();
                        flag = func();
                        #endregion

                    }
                    else
                    {
                        flag = false;
                    }
                    return flag;

                }, convertedDomainModel             
                );
        }
    }
}
