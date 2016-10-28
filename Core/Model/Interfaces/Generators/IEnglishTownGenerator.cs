using System.Collections.Generic;

namespace WaveTech.Dafuscator.Model.Interfaces.Generators
{
    public interface IEnglishTownGenerator
    {
        string GenerateEnglishTownName();
        List<string> GenerateEnglishTownNames(double count);
    }
}