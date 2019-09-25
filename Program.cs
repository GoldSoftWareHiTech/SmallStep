using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericQueryLibrary;
using System.Reflection;
using System.Linq.Expressions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************Test********************");


            ViewModel<string> viewModel = new ViewModelBlog() { 标题 = "Matrix", Count=10,CreateDateTime=DateTime.Now.AddYears(1),Content= "Matrix" }; //, ID=Guid.NewGuid()
            DomainModel<string> domainModel = new DomainModelBlog() { };

            #region MappingModel.ConvertViewModelToDataModel
            //MappingModel<string> mappingModel = new MappingModel<string>();
            //MappingModel<string>.ConvertViewModelToDataModel(viewModel, domainModel);
            //var domainProperties = domainModel.GetType().GetProperties();
            //foreach(var domainp in domainProperties)
            //{
            //    Console.WriteLine("Name=" + domainp.Name + "  Value=" + domainp.GetValue(domainModel)+" IsOrNotPredict="+domainModel.IsOrNotPredict(domainp));
            //}
            #endregion

            //#region  DomainModel and ViewModel Test

            //#region IsOrExistsQueryFieldAttribute
            //Console.WriteLine(domainModel.IsOrExistsQueryFieldAttribute("CreateDateTime"));
            //#endregion

            //#region GetPropertyValueByName
            //PropertyInfo domainProperty = domainModel.GetPropertyByName("Count");
            //domainProperty = null;
            //if(null!=domainProperty)
            //{
            //    Console.WriteLine(domainProperty.GetValue(domainModel));
            //}
            //object domainPropertyValue = domainModel.GetPropertyValueByName("CreateDateTime");
            //if (null == domainPropertyValue)
            //{
            //    Console.WriteLine("Null");
            //}
            //else
            //    Console.WriteLine(domainPropertyValue);
            //#endregion


            //#region GetPropertyValueByName
            ////object title = "线性代数";
            ////domainModel.SetPropertyValue("Title", title);
            ////Console.WriteLine(domainModel.GetPropertyValueByName("Title").ToString());
            //#endregion

            //#region SetPropertyValue GetPropertyValue
            //PropertyInfo viewModelPropertyInfo = viewModel.GetType().GetProperty("Count");
            //if (null != viewModelPropertyInfo)
            //{
            //    object viewModelPropertyValue = viewModel.GetPropertyValue(viewModelPropertyInfo);
            //    Console.WriteLine(viewModelPropertyValue);
            //    domainProperty = domainModel.GetPropertyByName("Count");
            //    domainModel.SetPropertyValue(viewModel, viewModelPropertyInfo,domainProperty);
            //    Console.WriteLine(domainProperty.GetValue(domainModel)==null?"Null":domainProperty.GetValue(domainModel));
            //}
            //#endregion

            //#region IsOrNotPredict
            //domainProperty = null;
            //domainProperty = domainModel.GetPropertyByName("CreateDateTime");
            //Console.WriteLine(domainModel.IsOrNotPredict(domainProperty) ? "Pass" : "Validate");

            //#endregion 

            //#endregion


            #region FieldQueryExpressionFactory
            FieldQueryExpressionT<string> fieldQueryExpressionT1 = FieldQueryExpressionFactory.CreateFieldQueryExpression<string>("Title", (m, n) => m.Trim().Contains(n.Trim()));

            //Console.WriteLine("Predict=" + fieldQueryExpressionT1.Predict("Asp.net", "Asp"));
            //Console.WriteLine("FieldName=" + fieldQueryExpressionT1.FieldName);
            //Console.WriteLine("CalculateResult=" + fieldQueryExpressionT1.CalculateResult("Asp.net", "Asp"));
            //Console.WriteLine("LeftExpression=" + fieldQueryExpressionT1.LeftQueryExpression);
            //Console.WriteLine("RightExpression=" + fieldQueryExpressionT1.RightQueryExpression);
            //Console.WriteLine("Result=" + fieldQueryExpressionT1.Result);
            //fieldQueryExpressionT1.Result = fieldQueryExpressionT1.CalculateResult("Asp.net", "Asp");

            FieldQueryExpressionT<int> fieldQueryExpressionT2 = FieldQueryExpressionFactory.CreateFieldQueryExpression<int>("Count", (m, n) => m == n);

            //Console.WriteLine("Predict=" + fieldQueryExpressionT2.Predict(100, 108));
            //Console.WriteLine("FieldName=" + fieldQueryExpressionT2.FieldName);
            //Console.WriteLine("CalculateResult=" + fieldQueryExpressionT2.CalculateResult(100, 108));
            //Console.WriteLine("LeftExpression=" + fieldQueryExpressionT2.LeftQueryExpression);
            //Console.WriteLine("RightExpression=" + fieldQueryExpressionT2.RightQueryExpression);
            //fieldQueryExpressionT2.Result = fieldQueryExpressionT2.CalculateResult(100, 108);
            //Console.WriteLine("Result=" + fieldQueryExpressionT2.Result);


            FieldQueryExpressionT<DateTime> fieldQueryExpressionT3 = FieldQueryExpressionFactory.CreateFieldQueryExpression<DateTime>("CreateDateTime", (m, n) => m == n);

            FieldQueryExpressionT<string> fieldQueryExpressionT4 = FieldQueryExpressionFactory.CreateFieldQueryExpression<string>("Content", (m, n) => m.Contains(n));

            FieldQueryExpressionT<Guid> fieldQueryExpressionT5 = FieldQueryExpressionFactory.CreateFieldQueryExpression<Guid>("标识", (m, n) => m.ToString() == n.ToString());

            //fieldQueryExpressionT3.Result = fieldQueryExpressionT3.CalculateResult(DateTime.Now, DateTime.Now.AddDays(1));
            //fieldQueryExpressionT3.Result = false;
            #endregion

            #region LogicalCalculationQueryExpression
            LogicalCalculationQueryExpression logicalCalculationQueryExpression = LogicalCalculationExpressionFactory.CreateLogicalCalculationQueryExpression(fieldQueryExpressionT1, fieldQueryExpressionT2, LogicalCalculationEnum.Or);
            LogicalCalculationQueryExpression logicalCalculationQueryExpression_2 = LogicalCalculationExpressionFactory.CreateLogicalCalculationQueryExpression(logicalCalculationQueryExpression, fieldQueryExpressionT5, LogicalCalculationEnum.And);
            
            //logicalCalculationQueryExpression = LogicalCalculationExpressionFactory.CreateLogicalCalculationQueryExpression(logicalCalculationQueryExpression, logicalCalculationQueryExpression_2,LogicalCalculationEnum.Or);

            //logicalCalculationQueryExpression = LogicalCalculationExpressionFactory.CreateLogicalCalculationQueryExpression(logicalCalculationQueryExpression, fieldQueryExpressionT3, LogicalCalculationEnum.Or);
            //Console.WriteLine("Logicalcalculation=" + logicalCalculationQueryExpression.Logicalcalculation);
            //Console.WriteLine("LeftExpression=" + ((FieldQueryExpressionT<string>)logicalCalculationQueryExpression.LeftQueryExpression).Result);
            //Console.WriteLine("RightExpression=" + ((FieldQueryExpressionT<int>)logicalCalculationQueryExpression.RightQueryExpression).Result);

            //LogicalCalculationQueryExpression logicalCalculationQueryExpression_2 = LogicalCalculationExpressionFactory.CreateLogicalCalculationQueryExpression(logicalCalculationQueryExpression, fieldQueryExpressionT2, LogicalCalculationEnum.Or);
            //LogicalCalculationQueryExpression logicalCalculationQueryExpression_3 = LogicalCalculationExpressionFactory.CreateLogicalCalculationQueryExpression(logicalCalculationQueryExpression_2, fieldQueryExpressionT2, LogicalCalculationEnum.Or);
            #endregion


            #region FieldQueryExpressionCollections

            //FieldQueryExpressionCollections fieldQueryExpressionCollections = QueryExpressionComplier.GetFieldExpressions(logicalCalculationQueryExpression);
            //List<string> lists = fieldQueryExpressionCollections.GetFieldQueryName();
            //foreach(string s in lists)
            //{
            //    Console.WriteLine(s);
            //}
            //FieldQueryExpression fieldQueryExpression = fieldQueryExpressionCollections.GetFieldQueryExpressionByFieldName("Title");
            //Console.WriteLine(fieldQueryExpression.FieldName);

            //fieldQueryExpressionCollections.SetFieldQueryExpressionResult(fieldQueryExpressionT1, false);
            //fieldQueryExpressionCollections.SetFieldQueryExpressionResult(fieldQueryExpressionT2, false);
            //fieldQueryExpressionCollections.SetFieldQueryExpressionResult(fieldQueryExpressionT3, true);
            #endregion

            #region QueryExpressionComplier
            //Expression expression = QueryExpressionComplier.GenerateExpressionQueryTree(logicalCalculationQueryExpression);
            #endregion

            #region GetLambdaExpresstionTree
            //Expression<Func<bool>> expression = QueryExpressionComplier.GetLambdaExpresstionTree(logicalCalculationQueryExpression);
            //Func<bool> func = expression.Compile();
            //Console.WriteLine(func());
            #endregion


            #region Clone
            //QueryExpression cloneQueryExpression = LogicalCalculationExpressionFactory.CreateEmptyLogicalCalculationQueryExpression();
            //QueryExpression clonedQueryExpression = logicalCalculationQueryExpression;
            //cloneQueryExpression = clonedQueryExpression.Clone() as QueryExpression;
            //fieldQueryExpressionT3 =FieldQueryExpressionFactory.CreateFieldQueryExpression<DateTime>("CreateDateTime", (m, n) => m > n);
            //fieldQueryExpressionT3.Result = true;
            //fieldQueryExpressionT3.FieldName = "CloneTest";

            //cloneQueryExpression = (clonedQueryExpression as LogicalCalculationQueryExpression).CloneLogicalCalculationQueryExpression() as LogicalCalculationQueryExpression;


            //cloneQueryExpression = null;
            //logicalCalculationQueryExpression.CloneQueryExpression(logicalCalculationQueryExpression, cloneQueryExpression);
            //cloneQueryExpression = logicalCalculationQueryExpression;
            //QueryExpression copyQueryExpression = cloneQueryExpression;

            #endregion


            #region Clone Test
            //Person p = null;
            //p = new Person();
            //p.Name = "Kate";
            //Address address = new Address() { Country = "UK" };
            //p.Address = address;

            ////p = p.Clone() as Person;
            //Person copyperson = p.ClonePerson() as Person;
            //p.Name = "Peter";
            //address.Country = "USA";
            //p.Address = address;

            ////Copy(p);
            //if (null == copyperson)
            //{
            //    Console.WriteLine("P is null");
            //}
            //else
            //{
            //    if (null == copyperson.Name)
            //    {
            //        Console.WriteLine("P.Name is null!");
            //    }
            //    else
            //    {
            //        Console.WriteLine(copyperson.Name);
            //    }

            //    if (null == copyperson.Address)
            //    {
            //        Console.WriteLine("P.Address is null!");
            //    }
            //    else
            //    {
            //        Console.WriteLine(copyperson.Address.Country);
            //    }

            //}
            #endregion

            #region QueryController
            QueryController queryController = new QueryController();
            Func<Func<DomainModel<String>, DomainModel<String>, bool>, DomainModel<String>, IEnumerable<DomainModel<String>> > func = (m, n) => Reposity.GetBlogs(m, n as DomainModelBlog);
            IEnumerable<DomainModel<string>> domainModelBlogs = queryController.GetDomainModels(logicalCalculationQueryExpression_2, viewModel, domainModel, func);
            List<DomainModelBlog> viewModels = domainModelBlogs as List<DomainModelBlog>;
            #endregion  

            Console.ReadKey();
        }


       
        private static void Copy(Person p)
        {
            p = new Person();
            p.Name = "Li";
        }


        private static IEnumerable<DomainModelBlog> GetDomainModelBlogsByKeyValue_1(QueryExpression queryExpression,DomainModel<string> domainModel,ViewModel<string> viewModel)
        {

            return null;
        }
    }

    public class Person:ICloneable
    {

        public string Name { get; set; }

        public Address Address { get; set; }

        public object Clone()
        {
            Person p = new Person();
            p.Name = "Li";
            return p;
        }

        public object ClonePerson()
        {
            Person p = new Person();
            p.Name = this.Name;
            p.Address = this.Address.Clone() as Address;
            return p;
            //return MemberwiseClone();

        }

    }

    public class Address:ICloneable
    {
        public string Country { get; set; }

        public object Clone()
        {
            return new Address() { Country = this.Country };
            //throw new NotImplementedException();
        }
    }


}
