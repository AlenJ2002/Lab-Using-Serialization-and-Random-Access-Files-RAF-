using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Event   // Task 1: Add the required keyword to the Event class
{
    public int EventNumber { get; set; }    // Task 1: Add the required keyword to the EventNumber property
    public required string Location { get; set; } // Task 1: Add the required keyword to the Location property
}

class Program   // Task 1: Add the required keyword to the Program class
{
    static void Main(string[] args)     // Task 1: Add the required keyword to the Main method
    {
        // Task 2: Create and assign values to an Event object
        Event myEvent = new Event { EventNumber = 1, Location = "Calgary" };

        // Task 3: Serialize this single Event object to a file called event.txt
        // Using JSON for safety, but storing in a .txt for the lab requirement
        string json = JsonConvert.SerializeObject(myEvent, Formatting.Indented); // Serialize the Event object
        File.WriteAllText("event.txt", json); // Write the JSON to a file

        // Task 4: Deserialize the Event object from event.txt
        string readJson = File.ReadAllText("event.txt"); // Read the JSON from the file
        Event deserializedEvent = JsonConvert.DeserializeObject<Event>(readJson); // Deserialize the JSON file
        Console.WriteLine($"{deserializedEvent.EventNumber}\n{deserializedEvent.Location}");    // Should print "Calgary"

        // Task 5: Create a list of 4 Event objects and serialize it into a JSON file
        List<Event> events = new List<Event>
        {
            new Event { EventNumber = 1, Location = "Calgary" },    
            new Event { EventNumber = 2, Location = "Vancouver" },
            new Event { EventNumber = 3, Location = "Toronto" },
            new Event { EventNumber = 4, Location = "Edmonton" }
        };
        string listJson = JsonConvert.SerializeObject(events, Formatting.Indented);     // Serialize the list
        File.WriteAllText("events.json", listJson); // Write the JSON to a file

        // Task 5 (continued): Deserialize the JSON file into a list of Event objects
        string readListJson = File.ReadAllText("events.json");
        List<Event> deserializedEvents = JsonConvert.DeserializeObject<List<Event>>(readListJson);  // Deserialize the JSON file
        foreach (Event e in deserializedEvents)
        {
            Console.WriteLine($"{e.EventNumber} {e.Location}"); // Should print all 4 events
        }

        // Task 6: Write and read from a file
        ReadFromFile("hackathon.txt");
    }

    // Task 6: Create a method called ReadFromFile
    public static void ReadFromFile(string filename) // Pass in the filename
    {
        // Write "Hackathon" to the file
        using (StreamWriter writer = new StreamWriter(filename))    // Open the file
        {
            writer.Write("Hackathon"); // Write "Hackathon" to the file 
        }
        Console.WriteLine("In Word: Hackathon"); // Should be "Hackathon"

        using (FileStream fs = new FileStream(filename, FileMode.Open)) // Open the file
        {
            // Read the first character
            int firstChar = fs.ReadByte();
            Console.WriteLine($"The First Character is: '{(char)firstChar}'");  // Should be 'H'

            // Seek to the middle character (assuming "Hackathon" is 9 characters, so index 4)
            fs.Seek(4, SeekOrigin.Begin);
            int middleChar = fs.ReadByte();
            Console.WriteLine($"The Middle Character is: '{(char)middleChar}'"); // Should be 'a'

            // Seek to the last character
            fs.Seek(-1, SeekOrigin.End);
            int lastChar = fs.ReadByte();
            Console.WriteLine($"The Last Character is: '{(char)lastChar}'"); // Should be 'n'
        }
    }
}
