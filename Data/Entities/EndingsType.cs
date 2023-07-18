namespace NameGenerator
{
    public sealed class EndingsType
    {
        public int EndingsTypeId { get; set; }

        public int LanguageId { get; set; }

        public Language Language { get; set; }

        public string EndingsTypeName { get; set; }
    }
}