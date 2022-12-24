using Model;

namespace ViewModel
{
    public class DoubleLetterRequirement
    {
        public DoubleLetterRequirement(Requirement requirement)
        {
            Requirement = requirement;
        }

        public string RequirementName => GetRequirementName(Requirement);

        private static string GetRequirementName(Requirement requirement) => requirement switch
        {
            Requirement.None => "Случайно",
            Requirement.Required => "Требуются",
            Requirement.Forbidden => "Запрещены"
        };

        public Requirement Requirement { get; set; }

    }
}