using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGC.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGC.Infrastructure.EntityConfig
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(pk => pk.Id);

            //AutoRelacionamento
            builder.HasMany(p => p.SubMenu)
                   .WithOne()
                   .HasForeignKey(fk => fk.MenuId);
        }
    }
}
