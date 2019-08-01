using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ModelValidation.Models
{
    #region О атрибутах проверки достоверности модели на уровне свойств
    /*Здесь используются два атрибута проверки достоверности - Required и Range. 
     * Атрибут Required указывает, что ошибка проверки достоверности возникает, 
     * если пользователь не отправил значение для свойства. Атрибут Range задает подмножество приемлемых значений.    
         */

    #endregion

    public class Appointment
    {
        [Required]
        [Display(Name ="name")]
        public string ClientName { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage ="Pleasy enter a date")]
        [Remote("ValidateDate","Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool),"true","true",ErrorMessage ="You must accept the terms")]
        [MustBeTrue(ErrorMessage ="You must accept the terms")]     //применение спеиального атрибута
        public bool TermsAccepted { get; set; }
    }
}
