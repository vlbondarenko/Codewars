﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;

namespace SportStore.Models.ViewModels
{
    public class ProductListViewPage
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
