namespace Model
{
    public sealed class EndingsType
    {
        private int _endingsTypeId;
        private int _languageId;
        private Language _language;
        private string _endingsTypeName;

        public int EndingsTypeId
        {
            get => _endingsTypeId;
            set
            {
                if (_endingsTypeId != value)
                {
                    _endingsTypeId = value;
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

        public string EndingsTypeName
        {
            get => _endingsTypeName;
            set
            {
                if (_endingsTypeName != value)
                {
                    _endingsTypeName = value;
                }
            }
        }
    }
}