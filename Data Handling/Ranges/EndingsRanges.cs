using System.Collections.Generic;

namespace NameGenerator
{
    internal sealed class EndingsRanges
    {
        internal EndingsRanges(List<string> female, List<string> male)
        {
            Female = female;
            Male = male;
        }

        internal List<string> Female { get; private set; }

        internal List<string> Male { get; private set; }
    }
}