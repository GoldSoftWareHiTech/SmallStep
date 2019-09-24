using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
   internal  class DataType
    {
        public static readonly int INT_ZERO = 0;

        public static readonly float FLOAT_ZERO = 0;

        public static readonly string STRING_EMPTY = string.Empty;

        public static readonly DateTime NOW_DATETIME = new DateTime();

        public static readonly Guid GUID = new Guid();

        public static readonly int? INTNULL = null;

        public static readonly bool? BOOLNULL = null;

     
    }
}
