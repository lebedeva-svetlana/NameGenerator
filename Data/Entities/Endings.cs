namespace NameGenerator
{
    public sealed class Endings
    {
        public int EndingsId { get; set; }

        public int EndingsTypeId { get; set; }

        public EndingsType EndingsType { get; set; }

        public string Ending { get; set; }

        public bool IsFemaleEnding { get; set; }
    }
}