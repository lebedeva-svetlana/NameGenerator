namespace Model
{
    public sealed class Language
    {
        private int _languageId;
        private string _languageName;

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

        public string LanguageName
        {
            get => _languageName;
            set
            {
                if (_languageName != value)
                {
                    _languageName = value;
                }
            }
        }
    }
}