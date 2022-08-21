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
    public class DespesasMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            //Definicação do Campo como Chave Primaria
            builder.HasKey(d => d.DespesaId);

            //Define o Campo Descrição como Not Null, e possui 50 Posições
            builder.Property(d => d.Descricao).IsRequired().HasMaxLength(50);
            //Os campos Abaixo são criados como Obrigatórios (Not Null)
            builder.Property(d => d.Valor).IsRequired();
            builder.Property(d => d.Dia).IsRequired();
            builder.Property(d => d.Ano).IsRequired();

            //Relacionamento On para Muitos, um cartão está relacionado com muitas despesas
            builder.HasOne( d => d.Cartao).WithMany( d => d.Despesas).HasForeignKey(d => d.DespesaId).IsRequired();
            //Relacionamento On para Muitos, uma Catergoria está relacionado com muitas despesas
            builder.HasOne(d => d.Categoria).WithMany( d => d.Despesas).HasForeignKey(d =>d.CategoriaId).IsRequired();  
            builder.HasOne(d => d.Mes).WithMany( d => d.Despesas).HasForeignKey(d => d.MesId).IsRequired();
            builder.HasOne(d => d.Usuario).WithMany( d => d.Despesas).HasForeignKey(d => d.UsuarioId).IsRequired();


            builder.ToTable("Despesas");


        }
    }
}
