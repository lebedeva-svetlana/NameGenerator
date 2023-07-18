namespace NameGenerator
{
    public sealed class FrequencyType
    {
        public int FrequencyTypeId { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string FrequencyTypeName { get; set; }
    }
}