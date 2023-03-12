﻿using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products"); 

            builder.HasKey(x => x.Id); 

            builder.Property(x=>x.price).IsRequired();

            builder.Property(x=>x.OriginalPrice).IsRequired().HasDefaultValue(0);

            builder.Property(x=>x.Stock).IsRequired().HasDefaultValue(0);

            builder.Property(x=>x.ViewCount).IsRequired().HasDefaultValue(0);

        }
    }
}
