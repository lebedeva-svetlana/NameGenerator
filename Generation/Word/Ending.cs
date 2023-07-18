using System;

namespace NameGenerator
{
    internal sealed class Ending
    {
        private GeneratorOptions _options;
        private Random _random = new();

        internal Ending(GeneratorOptions options)
        {
            _options = options;
        }

        internal string GenerateEnding(SexEnding type)
        {
            if (type == SexEnding.Any)
            {
                type = Convert.ToBoolean(_random.Next(2)) ? SexEnding.Female : SexEnding.Male;
            }

            return ChooseEndingByType(type);
        }

        private string ChooseEndingByType(SexEnding type) => type switch
        {
            SexEnding.Female => _options.Endings.Female[_random.Next(_options.Endings.Female.Count)],
            SexEnding.Male => _options.Endings.Male[_random.Next(_options.Endings.Male.Count)],
            _ => throw new ArgumentException($"{type} is not valid ending type.")
        };
    }
}