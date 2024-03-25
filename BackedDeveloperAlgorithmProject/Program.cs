using BackedDeveloperAlgorithmProject.Datasource;
using BackedDeveloperAlgorithmProject.Helpers;
using BackedDeveloperAlgorithmProject.Models;


TimeSpan startTime = DateTime.Now.TimeOfDay;
TimeSpan endTime = DateTime.Now.AddHours(6).TimeOfDay;

try
{
    // kullanıcıdan başlangıç saati alınıyor
    Console.WriteLine("Lütfen başlangıç saatinizi giriniz (Örn: 00:00): ");
    string? startDateStr = Console.ReadLine();
    startTime = TimeSpan.Parse(startDateStr!);

    // kullanıcıdan bitiş saati alınıyor
    Console.WriteLine("Lütfen bitiş saatinizi giriniz (Örn: 00:00): ");
    string? endDateStr = Console.ReadLine();
    endTime = TimeSpan.Parse(endDateStr!);
}
catch (Exception ex)
{
    Console.WriteLine("Saat formatını yanlış girdiniz!");
    Console.WriteLine("Kapatmak için bir tuşa basınız.");
    Console.ReadKey();
    return;
}

// event listesi getiriliyor
List<Event>? eventDs = EventDatasource
    .GetDataSource()?
    .ToList() ?? new List<Event>();


// DurationBetweenLocation listesi getiriliyor
List<DurationBetweenLocation>? durationBetweenLocationDs = DurationBetweenLocationDatasource
    .GetDataSource()?
    .ToList() ?? new List<DurationBetweenLocation>();

List<Event>? plannedEvents = EventHelper.PlanEvents(eventDs, durationBetweenLocationDs, startTime, endTime);

Console.WriteLine("Sonuç:");
Console.WriteLine($"Katılınabilecek Maksimum Etkinlik Sayısı: {plannedEvents.Count}");
Console.WriteLine($"Katılınabilecek Etkinliklerin ID'leri: {string.Join(",", plannedEvents.Select(x => x.Id).ToArray())}");
Console.WriteLine($"Toplam Değer: {plannedEvents.Sum(e => e.Priority)}");


Console.Read();