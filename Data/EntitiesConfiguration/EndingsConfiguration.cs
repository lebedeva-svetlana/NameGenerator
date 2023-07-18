using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NameGenerator
{
    internal class EndingsConfiguration : IEntityTypeConfiguration<Endings>
    {
        public void Configure(EntityTypeBuilder<Endings> builder)
        {
            builder
                .HasKey(endings => endings.EndingsId)
                .HasName("pk_endings");

            builder
                .HasOne(endings => endings.EndingsType)
                .WithMany()
                .HasConstraintName("fk_endings_type_endings")
                .HasForeignKey(endings => endings.EndingsTypeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasCheckConstraint("ch_is_female_ending", "is_female_ending IN (0, 1)");

            builder.Property(endings => endings.EndingsId)
                .HasColumnName("endings_id");
            builder.Property(endings => endings.EndingsTypeId)
                .HasColumnName("endings_type_id");
            builder.Property(endings => endings.Ending)
                .HasColumnName("ending")
                .IsRequired();
            builder.Property(endings => endings.IsFemaleEnding)
                .HasColumnName("is_female_ending");

            string[] female = new string[] { "а", "е", "и", "о", "у", "э", "ю", "я", "ая", "ея", "ия", "оя", "уя", "эя" };

            string[] male = new string[] { "б", "в", "г", "д", "ж", "й", "к", "л", "м", "н", "п", "р", "с", "т", "ф", "х" };

            int length = female.Length + male.Length;

            Endings[] endings = new Endings[length];

            for (int i = 0; i < female.Length; ++i)
            {
                endings[i] = new Endings
                {
                    EndingsId = i + 1,
                    EndingsTypeId = 1,
                    Ending = female[i],
                    IsFemaleEnding = true
                };
            }

            for (int i = female.Length; i < length; ++i)
            {
                endings[i] = new Endings
                {
                    EndingsId = i + 1,
                    EndingsTypeId = 1,
                    Ending = male[i - female.Length],
                    IsFemaleEnding = false
                };
            }

            builder.HasData(endings);

            builder.ToTable("endings");
        }
    }
}