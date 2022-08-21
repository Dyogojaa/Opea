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
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(c => c.CartaoId);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Nome).IsUnique();
            builder.Property(b => b.Bandeira).IsRequired().HasMaxLength(15);

            builder.Property(c => c.Numero).IsRequired().HasMaxLength(20);  
            builder.HasIndex(c => c.Numero).IsUnique();
            builder.Property(l => l.Limite).IsRequired();

            //Relacionamento 1 para Muitos
            //Um Usuário pode Ter muitos Cartoes
            //A Chave Estrangeira é Usuárioid
            //É Requerido o Cartão            
            builder.HasOne(c => c.Usuario).WithMany(c=> c.Cartaos).HasForeignKey(c=>c.UsuarioId).IsRequired().OnDelete(DeleteBehavior.NoAction);

            //Nesse relacionamento Muitos para 1, onde varias despesas estão relacionados apenas com um cartão.
            builder.HasMany(c => c.Despesas).WithOne(c => c.Cartao);

            builder.ToTable("Cartoes");



        }
    }
}
