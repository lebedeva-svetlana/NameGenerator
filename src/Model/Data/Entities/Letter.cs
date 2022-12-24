namespace Model
{
    public sealed class Letter
    {
        private int _letterId;
        private int _languageId;
        private Language _language;
        private char _char;
        private bool _isVowel;

        public int LetterId
        {
            get => _letterId;
            set
            {
                if (_letterId != value)
                {
                    _letterId = value;
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

        public char Char
        {
            get => _char;
            set
            {
                if (_char != value)
                {
                    _char = value;
                }
            }
        }

        public bool IsVowel
        {
            get => _isVowel;
            set
            {
                if (_isVowel != value)
                {
                    _isVowel = value;
                }
            }
        }
    }
}