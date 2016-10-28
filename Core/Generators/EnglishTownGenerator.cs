using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Reflection;
using WaveTech.Dafuscator.Model.Interfaces.Generators;
using WaveTech.Dafuscator.Model.Interfaces.Providers;

namespace WaveTech.Dafuscator.Generators
{
	public class EnglishTownGeneratorInfo : IGeneratorInfo
	{
		public Guid Id
		{
			get { return new Guid("2FBC8A78-B7A3-45C8-B21B-EA2C92D9A870"); }
		}

		public string Name
		{
			get { return "English Town Name Generator"; }
		}

		public Type Type
		{
			get { return typeof(IEnglishTownGenerator); }
		}

		public List<OleDbType> CompatibleDataTypes
		{
			get
			{
				return new List<OleDbType>
								{
									OleDbType.LongVarChar,
									OleDbType.LongVarWChar,
									OleDbType.VarChar,
									OleDbType.VarWChar
								};
			}
		}
	}

	public class EnglishTownGeneratorBuilder : IGeneratorBuilder
	{
		public Guid GeneratorId
		{
			get { return new Guid("337ECBFD-DB3B-48BB-8516-BA7DEA7DEC45"); }
		}

		public List<string> BuildGenerator(object generator, object[] data, HashSet<string> existingColumnData)
		{
			List<string> generatedData = null;

			if (generator != null && data.Length >= 1)
				generatedData = ((IEnglishTownGenerator)generator).GenerateEnglishTownNames((double)data[0]);

			return generatedData;
		}
	}

	public class EnglishTownGenerator : IEnglishTownGenerator
	{
		private static List<string> englishTownLines;

		private readonly INumberGenerator numberGenerator;
		private readonly IFileDataProvider fileDataProvider;

		public EnglishTownGenerator(INumberGenerator numberGenerator, IFileDataProvider fileDataProvider)
		{
			this.numberGenerator = numberGenerator;
			this.fileDataProvider = fileDataProvider;
		}

		private List<string> GetEnglishTownNames()
		{
			if (englishTownLines == null || englishTownLines.Count <= 0)
			{
				Assembly assembly = Assembly.GetExecutingAssembly();
				englishTownLines = fileDataProvider.GetDataFromEmbededFile(assembly, "WaveTech.Dafuscator.Generators.Data.EnglishTown.txt");
			}

			return englishTownLines;
		}

		public string GenerateEnglishTownName()
		{
			List<string> lines = GetEnglishTownNames();

			int randomNumber = numberGenerator.GenerateRandomNumber(0, lines.Count - 1);

			return lines[randomNumber];
		}

		public List<string> GenerateEnglishTownNames(double count)
		{
			List<string> cities = new List<string>();

			for (double i = 0; i < count; i++)
			{
				cities.Add(GenerateEnglishTownName());
			}

			return cities;
		}
	}
}
