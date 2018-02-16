using System;

namespace HealthInformationProgram.Data
{
    public sealed class Country
    {
        public Country(string name, string code)
        {
            Name = name;
            Code = code;
        }

        public string Name { get; }

        public string Code { get; }
    }
}
