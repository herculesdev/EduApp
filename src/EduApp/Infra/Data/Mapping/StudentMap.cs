using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    internal class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students").HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.Name).HasColumnName("name");
            builder.Property(s => s.Email).HasColumnName("email");
            builder.Property(s => s.RA).HasColumnName("ra");
            builder.Property(s => s.CPF).HasColumnName("cpf");
        }
    }
}
