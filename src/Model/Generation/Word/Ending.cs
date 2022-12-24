using System;

namespace Model
{
    internal sealed class Ending
    {
        internal Ending(GeneratorOptions options)
        {
            this.options = options;
        }

        private GeneratorOptions options;
        private Random random = new();

        private string ChooseEndingByType(SexEnding type) => type switch
        {
            SexEnding.Female => options.Endings.Female[random.Next(options.Endings.Female.Count)],
            SexEnding.Male => options.Endings.Male[random.Next(options.Endings.Male.Count)],
            _ => throw new ArgumentException($"{type} is not valid ending type.")
        };

        internal string GenerateEnding(SexEnding type)
        {
            if (type == SexEnding.Any)
            {
                type = Convert.ToBoolean(random.Next(2)) ? SexEnding.Female : SexEnding.Male;
            }

            return ChooseEndingByType(type);
        }
    }
}