namespace Model
{
    public sealed class FrequencyType
    {
        private int _frequencyTypeId;
        private int _languageId;
        private Language _language;
        private string _frequencyTypeName;

        public int FrequencyTypeId
        {
            get => _frequencyTypeId;
            set
            {
                if (_frequencyTypeId != value)
                {
                    _frequencyTypeId = value;
                }
            }
        }

        public int LanguageId
        {
            get => _languageId;
            set
            {
                if (_languageId != value)
                {
                    _languageId = value;
                }
            }
        }

        public Language Language
        {
            get => _language;
            set
            {
                if (_language != value)
                {
                    _language = value;
                }
            }
        }

        public string FrequencyTypeName
        {
            get => _frequencyTypeName;
            set
            {
                if (_frequencyTypeName != value)
                {
                    _frequencyTypeName = value;
                }
            }
        }
    }
}