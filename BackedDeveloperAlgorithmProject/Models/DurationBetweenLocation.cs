using Newtonsoft.Json;

namespace BackedDeveloperAlgorithmProject.Models;
public class DurationBetweenLocation
{
    public string? From { get; set; }
    public string? To { get; set; }

    [JsonProperty(PropertyName = "duration_minutes")]
    public int? DurationMinutes { get; set; }
}
