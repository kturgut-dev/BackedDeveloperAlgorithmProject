namespace BackedDeveloperAlgorithmProject.Helpers;
public static class JsonHelper
{
    public static string? Serialize<T>(T obj)
    {
        try
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
        catch (Exception ex)
        {
            return default;
        }
    }

    public static T? Deserialize<T>(string json)
    {
        try
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
        catch (Exception ex)
        {
            return default;
        }
    }

    public static IEnumerable<T>? ReadJsonFile<T>(string path)
    {
        try
        {
            string json = System.IO.File.ReadAllText(path);
            return Deserialize<IEnumerable<T>>(json);
        }
        catch (Exception ex)
        {
            return default;
        }
    }

    public static void WriteJsonFile<T>(string path, IEnumerable<T> data)
    {
        try
        {
            string json = Serialize(data);
            System.IO.File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
