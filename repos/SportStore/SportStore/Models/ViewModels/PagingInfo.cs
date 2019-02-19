﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models.ViewModels
{
    public class PagingInfo
    {
        public int TotalItem { get; set; }
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }  //текущая страница

        public int TotalPages => (int)Math.Ceiling((decimal) TotalItem/ItemPerPage);
    }
}
