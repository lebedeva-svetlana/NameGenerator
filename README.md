# NameGenerator

Fictional name generator.

## Usage

```cs
GeneratorOptions options = await GeneratorOptions.CreateAsync(1, 1, 1);

options.DoubleLetterFrequencyPercent = 10;
options.DoubleConsonantRequirement = Requirement.Forbidden;
options.DoubleVowelRequirement = Requirement.Required;

options.MaxConsonantInRow = 1;
options.MaxVowelInRow = 2;

options.SexEnding = SexEnding.Any;
options.Length = 7;

Generator generator = new(options);
string name = generator.Generate();
```



