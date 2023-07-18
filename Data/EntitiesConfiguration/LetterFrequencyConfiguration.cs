using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NameGenerator
{
    internal class LetterFrequencyConfiguration : IEntityTypeConfiguration<LetterFrequency>
    {
        public void Configure(EntityTypeBuilder<LetterFrequency> builder)
        {
            builder
                .HasOne(frequency => frequency.FrequencyType)
                .WithMany()
                .HasConstraintName("fk_frequency_type_letter_frequency")
                .HasForeignKey(frequency => frequency.FrequencyTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(frequency => frequency.Letter)
                .WithMany()
                .HasConstraintName("fk_letter_letter_frequency")
                .HasForeignKey(frequency => frequency.LetterId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasKey(nameof(LetterFrequency.FrequencyTypeId), nameof(LetterFrequency.LetterId));

            builder
                .HasCheckConstraint("ch_frequency", "frequency >= 0");

            builder.Property(letter => letter.FrequencyTypeId)
                .HasColumnName("frequency_type_id");
            builder.Property(letter => letter.LetterId)
                .HasColumnName("letter_id");
            builder.Property(frequency => frequency.Frequency)
                .HasColumnName("frequency");

            int[] frequenciesValue = new int[] { 801, 159, 454, 170, 298, 845, 4, 94, 165, 735, 121, 349, 440, 321, 670, 1097, 281, 473, 547, 626, 262, 26, 97, 38, 34, 23, 26, 190, 32, 64, 201 };

            LetterFrequency[] frequencies = new LetterFrequency[frequenciesValue.Length];

            for (int i = 0; i < frequenciesValue.Length; ++i)
            {
                frequencies[i] = new LetterFrequency
                {
                    FrequencyTypeId = 1,
                    LetterId = i + 1,
                    Frequency = frequenciesValue[i]
                };
            }

            builder.HasData(frequencies);

            builder.ToTable("letter_frequency");
        }
    }
}