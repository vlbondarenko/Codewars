﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class EFOrdesRepository:IOrderRepository
    {
        private ApplicationDbContext context;

        public EFOrdesRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Order> Orders => context.Orders.Include(o=>o.Lines).ThenInclude(l => l.Product);

        public void SaveOrder (Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID==0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }

    }
}
