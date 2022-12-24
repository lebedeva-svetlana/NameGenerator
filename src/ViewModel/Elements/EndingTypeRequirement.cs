using Model;

namespace ViewModel
{
    public class EndingTypeRequirement
    {
        public EndingTypeRequirement(SexEnding endingType)
        {
            EndingType = endingType;
        }

        public string EndingTypeName => GetRequirementName(EndingType);

        private string GetRequirementName(SexEnding endingType) => endingType switch
        {
            SexEnding.Any => "Любые",
            SexEnding.Female => "Женские",
            SexEnding.Male => "Мужские"
        };

        public SexEnding EndingType { get; set; }
    }
}