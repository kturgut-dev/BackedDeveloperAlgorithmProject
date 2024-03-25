using Newtonsoft.Json;

namespace BackedDeveloperAlgorithmProject.Models;
public class Event
{
    public int Id { get; set; }
    [JsonProperty(PropertyName = "start_time")]
    public TimeSpan? StartTime { get; set; }
    [JsonProperty(PropertyName = "end_time")]
    public TimeSpan? EndTime { get; set; }
    public string? Location { get; set; }
    public int? Priority { get; set; }
}