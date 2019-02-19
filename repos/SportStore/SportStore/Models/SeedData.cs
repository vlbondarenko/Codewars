﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SportStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name ="Kayak",
                        Description="A boat for one person",
                        Category="Watersport",
                        Price=275
                    },
                    new Product
                    {
                        Name="Lifejacket",
                        Description="Protective and fashionable",
                        Category="Watersport",
                        Price=48.95m
                    },
                    new Product
                    {
                        Name="Soccer Ball",
                        Description="FIFA-approved sithe and weifgt",
                        Category="Soccer",
                        Price=19.50m
                    },
                    new Product
                    {
                        Name="Corner Flag",
                        Description="Give your playing firld a professional touch",
                        Category="Soccer",
                        Price=34.95m
                    },
                    new Product
                    {
                        Name="Stadium",
                        Description="Flat-packed 35,000-seat stadium",
                        Category="Soccer",
                        Price=79500
                    },
                    new Product
                    {
                        Name="Thinking Cap",
                        Description="Improve brain efficiency by 75%",
                        Category="Chess",
                        Price=16
                    },
                    new Product
                    {
                        Name="Unsteady Chair",
                        Description="Secretly give your opponent a disadvantage",
                        Category="Chess",
                        Price=29.95m
                    },
                    new Product
                    {
                        Name="Human Chess Board",
                        Description="A fun game for famyly",
                        Category="Chess",
                        Price=75
                    },
                    new Product
                    {
                        Name="Bling-Bling King",
                        Description="Gold-plated, diamond-studded King",
                        Category="Chess",Price=1200
                    });
                context.SaveChanges();
            }
        }
    }
}
