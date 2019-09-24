using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
    //The type of key is FieldQueryExpressionT actually
    internal class FieldQueryExpressionCollections:Dictionary<FieldQueryExpression,bool ?>
    {

        //private Dictionary<FieldQueryExpression, bool?> _cacheDic = new Dictionary<FieldQueryExpression, bool?>();

        public List<string> GetFieldQueryName()
        {
            List<string> fields = new List<string>();
            fields = this.Keys.Select(t => t.FieldName).ToList();
            return fields;

        }

        public FieldQueryExpression GetFieldQueryExpressionByFieldName(string fieldname)
        {
            if (string.IsNullOrEmpty(fieldname)) throw new ArgumentNullException("Fieldname can't be null!");
            return this.Keys.Where(t=>t.FieldName==fieldname.Trim()).FirstOrDefault();
        }

        public  void  AddFieldQueryExpressionAndResult(FieldQueryExpression fieldQueryExpression, bool? result)
        {
            if (null == fieldQueryExpression) throw new ArgumentNullException("The FieldQueryExpression can't be null!");
            if (this.ContainsKey(fieldQueryExpression)) throw new Exception(string.Format("FieldQueryExpressionCollections  has already contained {0} FieldQueryExpression",fieldQueryExpression.FieldName));
            else
            {
                if (string.IsNullOrEmpty(fieldQueryExpression.FieldName.Trim()))
                {
                    throw new ArgumentNullException("The FieldQueryExpression's FieldName can't be null!");
                }
            }
            fieldQueryExpression.Result = result;

            //FieldQueryExpression test = fieldQueryExpression;

            base.Add(fieldQueryExpression, result);

        }

        public void ResetFieldQueryExpressionResult()
        {
            if (this.Count() == 0)
            {
                throw new Exception("The length of FieldQueryExpressionCollections can't be null!");
            }

            this.Clear(); 
        }



        public void SetFieldQueryExpressionResult(FieldQueryExpression fieldQueryExpression,bool ?result)
        {
            if (null == fieldQueryExpression) throw new ArgumentNullException("The FieldQueryExpression can't be null!");
            if (!this.ContainsKey(fieldQueryExpression)) { throw new Exception(string.Format("The collections dosn't exist {0} FieldQueryExpression", fieldQueryExpression.FieldName)); }
            fieldQueryExpression.Result = result;
            //this[this.Keys.Where(p => p.FieldName == fieldQueryExpression.FieldName).FirstOrDefault()] = null;
            this[this.Keys.Where(p => p.FieldName == fieldQueryExpression.FieldName).FirstOrDefault()] = result;  

        }

        public void SetFieldQueryExpressionResultTrue(FieldQueryExpression fieldQueryExpression)
        {
            if (null == fieldQueryExpression) throw new ArgumentNullException("The FieldQueryExpression can't be null!");
            SetFieldQueryExpressionResult(fieldQueryExpression, true);
        }
        public void SetFieldQueryExpressionResultFalse(FieldQueryExpression fieldQueryExpression)
        {
            if (null == fieldQueryExpression) throw new ArgumentNullException("The FieldQueryExpression can't be null!");
            SetFieldQueryExpressionResult(fieldQueryExpression, false);
        }


    }
}
