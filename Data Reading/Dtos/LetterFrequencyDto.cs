namespace NameGenerator
{
    public sealed class LetterFrequencyDto
    {
        public int FrequencyTypeId { get; set; }

        public int LetterId { get; set; }

        public int Frequency { get; set; }

        public bool IsVowel { get; set; }
    }
}