using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalControl.BLL.Models;

namespace TotalControl.DAL.Mapeamentos
{
    public class TipoMap : IEntityTypeConfiguration<Tipo>
    {
        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.HasKey(t => t.TipoId);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(20);


            builder.HasMany(t => t.Categorias).WithOne(t => t.Tipo);

            builder.HasData
                (
                new Tipo() 
                {
                    TipoId = 1,
                    Nome =  "Despesas"
                },
                new Tipo()
                {
                    TipoId = 2,
                    Nome = "Ganho"
                }                
                );
            builder.ToTable("Tipos");

        }
    }
}
