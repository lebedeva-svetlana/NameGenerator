using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NameGenerator
{
    internal class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder
                .HasKey(language => language.LanguageId)
                .HasName("pk_language");

            builder
                .HasIndex(language => language.LanguageName).IsUnique();

            builder.Property(letter => letter.LanguageId)
                .HasColumnName("language_id");
            builder.Property(language => language.LanguageName)
                .HasColumnName("language_name")
                .IsRequired();

            builder.HasData(
                new Language
                {
                    LanguageId = 1,
                    LanguageName = "Russian"
                }
            );

            builder.ToTable("language");
        }
    }
}