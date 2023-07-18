using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NameGenerator
{
    internal class EndingsTypeConfiguration : IEntityTypeConfiguration<EndingsType>
    {
        public void Configure(EntityTypeBuilder<EndingsType> builder)
        {
            builder
                .HasKey(type => type.EndingsTypeId)
                .HasName("pk_endings_type");

            builder
                .HasOne(type => type.Language)
                .WithMany()
                .HasConstraintName("fk_language_endings_type")
                .HasForeignKey(type => type.LanguageId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(type => type.EndingsTypeId)
                .HasColumnName("endings_type_id");
            builder.Property(type => type.LanguageId)
                .HasColumnName("language_id");
            builder.Property(type => type.EndingsTypeName)
                .HasColumnName("endings_type_name")
                .IsRequired();

            builder.HasData(
                new EndingsType
                {
                    EndingsTypeId = 1,
                    LanguageId = 1,
                    EndingsTypeName = "Standard"
                }
                );

            builder.ToTable("endings_type");
        }
    }
}