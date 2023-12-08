using System.Collections.Concurrent;
using AdventOfCode_2023.Day5;

namespace AdventOfCode_2023.Day5;

public class AlmanacLoader
{
    public HashSet<long> Seeds = new();
    public List<Tuple<long, long>> SeedTuple = new();
    public ConcurrentDictionary<long, long> SeedsToUpdatedSeed = new();
    
    public ConditionMapper SeedToSoil;
    public ConditionMapper SoilToFertilizer;
    public ConditionMapper FertilizerToWater;
    public ConditionMapper WaterToLight;
    public ConditionMapper LightToTemperature;
    public ConditionMapper TemperatureToHumidity;
    public ConditionMapper HumidityToLocation;

    public void LoadFromInput(string[] input)
    {
        // This is a mess, but I don't really care, it works
        var seedsLoaded = false;
        var section = -1;

        var seedToSoil = new List<string>();
        var soilToFertilizer = new List<string>();
        var fertilizerToWater = new List<string>();
        var waterToLight = new List<string>();
        var lightToTemperature = new List<string>();
        var temperatureToHumidity = new List<string>();
        var humidityToLocation = new List<string>();

        foreach (var line in input)
        {
            // Load seeds
            if (!seedsLoaded && line.Contains("seeds:"))
            {
                LoadSeeds(line);
                seedsLoaded = true;
                continue;
            }

            // Reset section to stop loading if we hit an empty line
            if (line.Equals(""))
            {
                section = -1;
                continue;
            }

            // Set section on title
            if (Char.IsLetter(line[0]))
            {
                section = GetSection(line);
            }

            switch (section)
            {
                case 0:
                    seedToSoil.Add(line);
                    break;
                case 1:
                    soilToFertilizer.Add(line);
                    break;
                case 2:
                    fertilizerToWater.Add(line);
                    break;
                case 3:
                    waterToLight.Add(line);
                    break;
                case 4:
                    lightToTemperature.Add(line);
                    break;
                case 5:
                    temperatureToHumidity.Add(line);
                    break;
                case 6:
                    humidityToLocation.Add(line);
                    break;
            }
        }

        SeedToSoil = PopulateConditionMapper(seedToSoil);
        SoilToFertilizer = PopulateConditionMapper(soilToFertilizer);
        FertilizerToWater = PopulateConditionMapper(fertilizerToWater);
        WaterToLight = PopulateConditionMapper(waterToLight);
        LightToTemperature = PopulateConditionMapper(lightToTemperature);
        TemperatureToHumidity = PopulateConditionMapper(temperatureToHumidity);
        HumidityToLocation = PopulateConditionMapper(humidityToLocation);
    }

    public void LoadFromInputT2(string[] input)
    {
        // This is a mess, but I don't really care, it works
        var seedsLoaded = false;
        var section = -1;

        var seedToSoil = new List<string>();
        var soilToFertilizer = new List<string>();
        var fertilizerToWater = new List<string>();
        var waterToLight = new List<string>();
        var lightToTemperature = new List<string>();
        var temperatureToHumidity = new List<string>();
        var humidityToLocation = new List<string>();

        foreach (var line in input)
        {
            // Load seeds
            if (!seedsLoaded && line.Contains("seeds:"))
            {
                LoadSeedsT2(line);
                seedsLoaded = true;
                continue;
            }

            // Reset section to stop loading if we hit an empty line
            if (line.Equals(""))
            {
                section = -1;
                continue;
            }

            // Set section on title
            if (Char.IsLetter(line[0]))
            {
                section = GetSection(line);
            }

            switch (section)
            {
                case 0:
                    seedToSoil.Add(line);
                    break;
                case 1:
                    soilToFertilizer.Add(line);
                    break;
                case 2:
                    fertilizerToWater.Add(line);
                    break;
                case 3:
                    waterToLight.Add(line);
                    break;
                case 4:
                    lightToTemperature.Add(line);
                    break;
                case 5:
                    temperatureToHumidity.Add(line);
                    break;
                case 6:
                    humidityToLocation.Add(line);
                    break;
            }
        }

        SeedToSoil = PopulateConditionMapper(seedToSoil);
        SoilToFertilizer = PopulateConditionMapper(soilToFertilizer);
        FertilizerToWater = PopulateConditionMapper(fertilizerToWater);
        WaterToLight = PopulateConditionMapper(waterToLight);
        LightToTemperature = PopulateConditionMapper(lightToTemperature);
        TemperatureToHumidity = PopulateConditionMapper(temperatureToHumidity);
        HumidityToLocation = PopulateConditionMapper(humidityToLocation);
    }

    private int GetSection(string line)
    {
        return line switch
        {
            "seed-to-soil map:" => 0,
            "soil-to-fertilizer map:" => 1,
            "fertilizer-to-water map:" => 2,
            "water-to-light map:" => 3,
            "light-to-temperature map:" => 4,
            "temperature-to-humidity map:" => 5,
            "humidity-to-location map:" => 6,
            _ => -1
        };
    }

    private void LoadSeeds(string line)
    {
        var updatedLine = line.Replace("seeds:", "");
        var seeds = updatedLine.Split(" ");
        foreach (var seed in seeds)
        {
            if (!seed.Trim().Equals(""))
            {
                var newSeed = long.Parse(seed);
                Seeds.Add(newSeed);
                SeedsToUpdatedSeed.TryAdd(newSeed, newSeed);
            }
        }
    }

    private void LoadSeedsT2(string line)
    {
        var updatedLine = line.Replace("seeds:", "");
        var seeds = updatedLine.Split(" ");
        var seedTuple = new List<Tuple<long, long>>();

        long startSeed = 0;
        long range = 0;

        for (var i = 0; i < seeds.Length; i++)
        {
            if (seeds[i].Trim().Equals("")) continue;

            if (i % 2 != 0)
            {
                startSeed = long.Parse(seeds[i]);
            }
            else
            {
                range = long.Parse(seeds[i]);
                seedTuple.Add(new Tuple<long, long>(startSeed, range));

                startSeed = 0;
                range = 0;
            }
        }

        SeedTuple = seedTuple;
    }

    private ConditionMapper PopulateConditionMapper(List<string> values)
    {
        var conditionMapper = new ConditionMapper();
        for (var i = 1; i < values.Count; i++)
        {
            conditionMapper.Conditions.Add(CreateCondition(values[i]));
        }

        return conditionMapper;
    }

    private Condition CreateCondition(string line)
    {
        var splitValues = line.Split(" ");
        return new Condition(long.Parse(splitValues[1]), long.Parse(splitValues[0]), long.Parse(splitValues[2]));
    }
}