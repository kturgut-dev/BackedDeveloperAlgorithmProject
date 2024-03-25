using BackedDeveloperAlgorithmProject.Models;

namespace BackedDeveloperAlgorithmProject.Helpers;
public static class EventHelper
{
    public static List<Event> PlanEvents(List<Event>? eventDs, List<DurationBetweenLocation>? durationBetweenLocationDs, TimeSpan startTime, TimeSpan endTime)
    {

        //// event listesi getiriliyor
        //List<Event>? eventDs = EventDatasource
        //    .GetDataSource()?
        //    .ToList() ?? new List<Event>();


        //// DurationBetweenLocation listesi getiriliyor
        //List<DurationBetweenLocation>? durationBetweenLocationDs = DurationBetweenLocationDatasource
        //    .GetDataSource()?
        //    .ToList() ?? new List<DurationBetweenLocation>();


        // 2 saat arasında katılabileceği event'lar bulunuyor
        List<Event>? availableEvents = eventDs!
                   .Where(e => e.StartTime >= startTime && e.EndTime <= endTime)
                   .OrderByDescending(e => e.Priority)
                   .ToList();

        List<Event> plannedEvents = new List<Event>();

        // event'lar hepsi silinene kadar döngü devam ediyor
        while (availableEvents.Any())
        {
            Event? selectedEvent = availableEvents.First();
            plannedEvents.Add(selectedEvent);

            foreach (Event? nextEvent in availableEvents)
            {
                // event'lar arasındaki sürelerin hesaplanması
                int? travelTime = durationBetweenLocationDs
                    .Where(d => d.From == selectedEvent.Location && d.To == nextEvent.Location)
                    .Select(d => d.DurationMinutes)
                    .FirstOrDefault();

                if ((travelTime ?? 0) != 0)
                {
                    // bir sonraki etkinliğe ne zaman katılabilir
                    TimeSpan? nextEventStartTime = selectedEvent.EndTime?.Add(TimeSpan.FromMinutes(Convert.ToDouble(travelTime ?? 0)));
                    if (nextEventStartTime <= nextEvent.StartTime)
                    {
                        selectedEvent = nextEvent;
                        plannedEvents.Add(selectedEvent);
                    }
                }
            }

            // event listeden çıkarılıyor tekrar'a girmemesi için
            availableEvents.Remove(selectedEvent);
        }

        return plannedEvents;
    }
}
