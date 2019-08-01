using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MvcModels.Models
{
    //[Bind(nameof(City))]    //использование избирательной привязки моделей. В таком случае только указанное свойство будет принимать участие в привязке моделей. Другие свойства привязываться не будут
    public class AdressSummary
    {
        public string City { get; set; }

        //[BindNever]     //Явное исключение свойства из  процесса привязки
        public string Country { get; set; }
    }
}
