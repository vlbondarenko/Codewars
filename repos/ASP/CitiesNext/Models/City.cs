﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Cities.Models
{
    public class City
    {
        [Display(Name ="City")]     //установка содержимого элемента label в форме
        public string Name { get; set; }
        public string Country { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}",ApplyFormatInEditMode =true)]
        public int? Population { get; set; }
    }
}
