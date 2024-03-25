using BackedDeveloperAlgorithmProject.Helpers;
using BackedDeveloperAlgorithmProject.Models;

namespace BackedDeveloperAlgorithmProject.Datasource;
public static class DurationBetweenLocationDatasource
{
    public static IEnumerable<DurationBetweenLocation>? GetDataSource()
    {
        // read wwwroot/duration_between_locations_minutes_matix.json file and return ds
        return JsonHelper.ReadJsonFile<DurationBetweenLocation>($"wwwroot/duration_between_locations_minutes_matix.json") ?? new List<DurationBetweenLocation>
        {
            new DurationBetweenLocation { From = "A", To = "B", DurationMinutes = 15 },
            new DurationBetweenLocation { From = "A", To = "C", DurationMinutes = 20 },
            new DurationBetweenLocation { From = "A", To = "D", DurationMinutes = 10 },
            new DurationBetweenLocation { From = "B", To = "C", DurationMinutes = 5 },
            new DurationBetweenLocation { From = "B", To = "D", DurationMinutes = 25 },
            new DurationBetweenLocation { From = "C", To = "D", DurationMinutes = 25 }
        };
    }
}
