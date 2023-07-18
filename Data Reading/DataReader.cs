using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace NameGenerator
{
    internal static class DataReader
    {
        private static readonly ApplicationContextFactory contextFactory = new();

        internal static async Task<EndingsDto[]> LoadEndings(int endingsTypeId)
        {
            using ApplicationContext context = contextFactory.CreateDbContext();

            EndingsDto[] endings = await context.Endings
                .Where(ending => ending.EndingsTypeId == endingsTypeId)
                .Select(ending => new EndingsDto
                {
                    EndingTypeId = ending.EndingsTypeId,
                    Ending = ending.Ending,
                    IsFemaleEnding = ending.IsFemaleEnding
                })
                .ToArrayAsync();

            return endings;
        }

        internal static async Task<LetterFrequencyDto[]> LoadLetterFrequency(int frequencyTypeId)
        {
            using ApplicationContext context = contextFactory.CreateDbContext();

            LetterFrequencyDto[] frequencies = await context.LetterFrequencies
                .Where(frequency => frequency.FrequencyTypeId == frequencyTypeId)
                .Select(frequency => new LetterFrequencyDto
                {
                    LetterId = frequency.LetterId,
                    FrequencyTypeId = frequency.FrequencyTypeId,
                    Frequency = frequency.Frequency,
                    IsVowel = frequency.Letter.IsVowel
                })
                .ToArrayAsync();

            return frequencies;
        }

        internal static async Task<LetterDto[]> LoadLetters(int alphabetId)
        {
            using ApplicationContext context = contextFactory.CreateDbContext();

            LetterDto[] letters = await context.Letters
                .Where(letter => letter.LanguageId == alphabetId)
                .Select(letter => new LetterDto
                {
                    LanguageId = letter.LanguageId,
                    LetterId = letter.LetterId,
                    Char = letter.Char,
                    IsVowel = letter.IsVowel
                })
                .ToArrayAsync();

            return letters;
        }
    }
}