namespace NameGenerator
{
    public sealed class LetterFrequency
    {
        public int FrequencyTypeId { get; set; }

        public FrequencyType FrequencyType { get; set; }

        public int LetterId { get; set; }

        public Letter Letter { get; set; }

        public int Frequency { get; set; }
    }
}