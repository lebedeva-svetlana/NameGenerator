namespace NameGenerator
{
    internal sealed class FrequencyRanges
    {
        internal FrequencyRanges(int[] start, int[] end)
        {
            Start = start;
            End = end;
        }

        internal int[] End { get; private set; }

        internal int[] Start { get; private set; }
    }
}