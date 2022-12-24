namespace Model
{
    public sealed class Endings
    {
        private int _endingsId;
        private int _endingsTypeId;
        private EndingsType _endingsType;
        private string _ending;
        private bool _isFemaleEnding;

        public int EndingsId
        {
            get => _endingsId;
            set
            {
                if (_endingsId != value)
                {
                    _endingsId = value;
                }
            }
        }

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

        public EndingsType EndingsType
        {
            get => _endingsType;
            set
            {
                if (_endingsType != value)
                {
                    _endingsType = value;
                }
            }
        }

        public string Ending
        {
            get => _ending;
            set
            {
                if (_ending != value)
                {
                    _ending = value;
                }
            }
        }

        public bool IsFemaleEnding
        {
            get => _isFemaleEnding;
            set
            {
                if (_isFemaleEnding != value)
                {
                    _isFemaleEnding = value;
                }
            }
        }
    }
}