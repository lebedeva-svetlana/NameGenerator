using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NameGenerator
{
    internal class LetterConfiguration : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> builder)
        {
            builder
                .HasKey(letter => letter.LetterId)
                .HasName("pk_letter");

            builder
                .HasOne(letter => letter.Language)
                .WithMany()
                .HasConstraintName("fk_language_letter")
                .HasForeignKey(latter => latter.LanguageId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasIndex(letter => letter.Char).IsUnique();

            builder
                .HasCheckConstraint("ch_is_vowel", "is_vowel IN (0, 1)");

            builder.Property(letter => letter.LetterId)
                .HasColumnName("letter_id");
            builder.Property(letter => letter.LanguageId)
                .HasColumnName("language_id");
            builder.Property(letter => letter.Char)
                .HasMaxLength(1)
                .HasColumnName("char");
            builder.Property(letter => letter.IsVowel)
                .HasColumnName("is_vowel");

            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщыэюя";
            string vowelMask = "1000011001000001000010000001111";

            int length = alphabet.Length;

            Letter[] letters = new Letter[length];

            for (int i = 0; i < length; ++i)
            {
                bool isVowel = vowelMask[i] == '1';

                letters[i] = new Letter
                {
                    LetterId = i + 1,
                    LanguageId = 1,
                    Char = alphabet[i],
                    IsVowel = isVowel
                };
            }

            builder.HasData(letters);

            builder.ToTable("letter");
        }
    }
}