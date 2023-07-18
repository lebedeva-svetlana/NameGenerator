using System.Collections.Generic;
using System.Threading.Tasks;

namespace NameGenerator
{
    internal static class EndingsHelper
    {
        internal static async Task<EndingsRanges> GetEndings(int endingsTypeId)
        {
            EndingsDto[] endings = await DataReader.LoadEndings(endingsTypeId);

            List<string> female = new();
            List<string> male = new();

            for (int i = 0; i < endings.Length; ++i)
            {
                if (endings[i].IsFemaleEnding)
                {
                    female.Add(endings[i].Ending);
                }
                else
                {
                    male.Add(endings[i].Ending);
                }
            }

            return new EndingsRanges(female, male);
        }
    }
}