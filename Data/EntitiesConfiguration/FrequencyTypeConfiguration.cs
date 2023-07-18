using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NameGenerator
{
    internal class FrequencyTypeConfiguration : IEntityTypeConfiguration<FrequencyType>
    {
        public void Configure(EntityTypeBuilder<FrequencyType> builder)
        {
            builder
                .HasKey(type => type.FrequencyTypeId)
                .HasName("pk_frequency_type");

            builder
                .HasOne(type => type.Language)
                .WithMany()
                .HasConstraintName("fk_language_frequency_type")
                .HasForeignKey(type => type.LanguageId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(type => type.FrequencyTypeName).IsUnique();

            builder.Property(type => type.FrequencyTypeId)
                .HasColumnName("frequency_type_id");
            builder.Property(type => type.LanguageId)
                .HasColumnName("language_id");
            builder.Property(type => type.FrequencyTypeName)
                .HasColumnName("frequency_type_name")
                .IsRequired();

            builder.HasData(
                new FrequencyType
                {
                    FrequencyTypeId = 1,
                    LanguageId = 1,
                    FrequencyTypeName = "Standard"
                }
            );

            builder.ToTable("frequency_type");
        }
    }
}