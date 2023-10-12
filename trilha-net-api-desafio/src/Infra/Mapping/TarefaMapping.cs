using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Infra.Mapping
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        /*public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusTarefa Status { get; set; }*/
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Titulo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Data)
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Status)
                .IsRequired();
               
        }
    }
}
