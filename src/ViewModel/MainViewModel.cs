using CommunityToolkit.Mvvm.Input;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion INotifyPropertyChanged

        public MainViewModel()
        {
            CreateGeneratorCommand = new AsyncRelayCommand(CreateGenerator);
            GenerateCommand = new RelayCommand(Generate);

            Task.Run(() => CreateGenerator());
        }

        private const int MaxNames = 15;
        private string _names;

        private EndingTypeRequirement _selectedSexEnding;

        private Generator generator;
        private GeneratorOptions options;

        private int _maxVowelInRow = 1;
        private int _maxConsonantInRow = 1;

        private DoubleLetterRequirement _doubleConsonantRequirement;
        private DoubleLetterRequirement _doubleVowelequirement;

        private int _length = 5;

        public ObservableCollection<string> Languages { get; } = new() { "Русский язык" };

        public ObservableCollection<string> LetterFrequencyTypes { get; } = new() { "Стандартная" };

        public ObservableCollection<string> EndingsTypes { get; } = new() { "Стандартные" };

        public ObservableCollection<DoubleLetterRequirement> DoubleConsonantRequirements { get; } = new()
        {
            new DoubleLetterRequirement(Requirement.None),
            new DoubleLetterRequirement(Requirement.Required),
            new DoubleLetterRequirement(Requirement.Forbidden)
        };

        public ObservableCollection<DoubleLetterRequirement> DoubleVowelRequirements { get; } = new()
        {
            new DoubleLetterRequirement(Requirement.None),
            new DoubleLetterRequirement(Requirement.Required),
            new DoubleLetterRequirement(Requirement.Forbidden)
        };

        public ObservableCollection<EndingTypeRequirement> EndingTypeRequirements { get; } = new()
        {
            new EndingTypeRequirement(SexEnding.Any),
            new EndingTypeRequirement(SexEnding.Female),
            new EndingTypeRequirement(SexEnding.Male)
        };

        public EndingTypeRequirement SelectedSexType
        {
            get => _selectedSexEnding;
            set
            {
                if (_selectedSexEnding != value)
                {
                    _selectedSexEnding = value;
                    if (options is not null)
                    {
                        options.SexEnding = value.EndingType;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public string Names
        {
            get => _names;
            set
            {
                if (_names != value)
                {
                    _names = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MaxVowelInRow
        {
            get => _maxVowelInRow;
            set
            {
                if (_maxVowelInRow != value)
                {
                    _maxVowelInRow = value;
                    options.MaxVowelInRow = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MaxConsonantInRow
        {
            get => _maxConsonantInRow;
            set
            {
                if (_maxConsonantInRow != value)
                {
                    _maxConsonantInRow = value;
                    options.MaxConsonantInRow = value;
                    OnPropertyChanged();
                }
            }
        }

        public DoubleLetterRequirement DoubleConsonantRequirement
        {
            get => _doubleConsonantRequirement;
            set
            {
                if (_doubleConsonantRequirement != value)
                {
                    _doubleConsonantRequirement = value;
                    if (options is not null)
                    {
                        options.DoubleConsonantRequirement = value.Requirement;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public DoubleLetterRequirement DoubleVowelRequirement
        {
            get => _doubleVowelequirement;
            set
            {
                if (_doubleVowelequirement != value)
                {
                    _doubleVowelequirement = value;
                    if (options is not null)
                    {
                        options.DoubleVowelRequirement = value.Requirement;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public int Length
        {
            get => _length;
            set
            {
                if (_length != value)
                {
                    _length = value;
                    options.Length = _length;
                    OnPropertyChanged();
                }
            }
        }

        public IRelayCommand GenerateCommand { get; set; }

        public IAsyncRelayCommand CreateGeneratorCommand { get; set; }

        private async Task CreateGenerator()
        {
            options = await GeneratorOptions.CreateAsync(1, 1, 1);
            generator = new(options);

            //Generate();
        }

        private void Generate()
        {
            Names = "";

            for (int i = 0; i < MaxNames; ++i)
            {
                Names += generator.Generate() + Environment.NewLine;
            }
        }
    }
}