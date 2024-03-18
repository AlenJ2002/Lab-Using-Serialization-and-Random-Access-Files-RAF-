using Newtonsoft.Json;
using System.Xml;

internal static class ProgramHelpers
{
    static void Main(string[] args, JsonConvert jsonConvert)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        if (jsonConvert is null)
        {
            throw new ArgumentNullException(nameof(jsonConvert));
        }
        // Task 2: Create and assign values to an Event object
        Event myEvent = new Event { EventNumber = 1, Location = "Calgary" };

        // Task 3: Serialize this single Event object to a file called event.txt
        // Using JSON for safety, but storing in a .txt for the lab requirement
        string json = JsonConvert.SerializeObject(myEvent, Formatting.Indented);
        File.WriteAllText("event.txt", json);

        // Task 4: Deserialize the Event object from event.txt
        string readJson = File.ReadAllText("event.txt");
        Event deserializedEvent = jsonConvert.DeserializeObject<Event>(readJson);
        Console.WriteLine($"{deserializedEvent.EventNumber}\n{deserializedEvent.Location}");

        // Task 5: Create a list of 4 Event objects and serialize it into a JSON file
        List<Event> events = new List<Event>
            {
                new Event { EventNumber = 1, Location = "Calgary" },
                new Event { EventNumber = 2, Location = "Vancouver" },
                new Event { EventNumber = 3, Location = "Toronto" },
                new Event { EventNumber = 4, Location = "Edmonton" }
            };
        string listJson = JsonConvert.SerializeObject(events, Formatting.Indented);
        File.WriteAllText("events.json", listJson);

        // Task 5 (continued): Deserialize the JSON file into a list of Event objects
        string readListJson = File.ReadAllText("events.json");
        List<Event> deserializedEvents = JsonConvert.DeserializeObject<List<Event>>(readListJson);
        foreach (Event e in deserializedEvents)
        {
            Console.WriteLine($"{e.EventNumber} {e.Location}");
        }

        // Task 6: Write and read from a file
        ReadFromFile("hackathon.txt");
    }
}