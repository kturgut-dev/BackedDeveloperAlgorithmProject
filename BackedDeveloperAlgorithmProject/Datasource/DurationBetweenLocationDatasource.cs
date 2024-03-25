using BackedDeveloperAlgorithmProject.Helpers;
using BackedDeveloperAlgorithmProject.Models;

namespace BackedDeveloperAlgorithmProject.Datasource;
public static class DurationBetweenLocationDatasource
{
    public static IEnumerable<DurationBetweenLocation>? GetDataSource()
    {
        // read wwwroot/duration_between_locations_minutes_matix.json file and return ds
        return JsonHelper.ReadJsonFile<DurationBetweenLocation>($"wwwroot/duration_between_locations_minutes_matix.json") ?? new List<DurationBetweenLocation>();
    }
}
