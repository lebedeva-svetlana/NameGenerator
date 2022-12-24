namespace Model
{
    public sealed class LetterFrequency
    {
        private int _frequencyTypeId;
        private FrequencyType _frequencyType;
        private int _letterId;
        private Letter _letter;
        private int _frequency;

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

        public FrequencyType FrequencyType
        {
            get => _frequencyType;
            set
            {
                if (_frequencyType != value)
                {
                    _frequencyType = value;
                }
            }
        }

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

        public Letter Letter
        {
            get => _letter;
            set
            {
                if (_letter != value)
                {
                    _letter = value;
                }
            }
        }

        public int Frequency
        {
            get => _frequency;
            set
            {
                if (_frequency != value)
                {
                    _frequency = value;
                }
            }
        }
    }
}