using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueryLibrary
{
    public interface IModel<T>
    {

       T ModelID { get; set; }


    }
}

