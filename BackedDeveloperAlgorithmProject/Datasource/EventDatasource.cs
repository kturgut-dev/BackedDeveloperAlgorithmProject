using BackedDeveloperAlgorithmProject.Helpers;
using BackedDeveloperAlgorithmProject.Models;

namespace BackedDeveloperAlgorithmProject.Datasource;
public static class EventDatasource
{
    public static IEnumerable<Event>? GetDataSource()
    {
        // read wwwroot/event.json file and return ds
        return JsonHelper.ReadJsonFile<Event>($"wwwroot/events.json") ?? new List<Event>();
    }
}
