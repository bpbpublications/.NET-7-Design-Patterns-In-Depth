using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public interface IGISService
{
    string GetLatLng(string name);
}
public class GISService : IGISService
{
    static readonly Dictionary<string, string> map = new()
        {
            { "Tehran", "35.44°N,51.30°E" },
            { "Urmia", "37.54°N,45.07°E" },
            { "Khorramabad", "33.46°N,48.33°E" },
            { "Shahrekord", "32.32°N,50.87°E" },
            { "Zahedan", "29.45°N,60.88°E" },
            { "Ilam", "33.63°N,46.41°E" },
            { "Yasuj", "30.66°N,51.58°E" },
            { "Ahvaz", "31.31°N,48.67°E" },
            { "Rasht", "37.26°N,49.58°E" },
            { "Sari", "36.56°N,53.05°E" },
            { "Sanandaj", "35.32°N,46.98°E" },
            { "Ardabil", "37.54°N,45.07°E" }
        };
    public string GetLatLng(string name)
    {
        Thread.Sleep(5000);
        return map.FirstOrDefault(x => x.Key == name).Value;
    }
}
public class GISServiceProxy : IGISService
{
    static readonly Dictionary<string, string> mapCache = new();
    static readonly GISService _gisService = new();
    public string GetLatLng(string name)
    {
        var requestOn = DateTime.Now.TimeOfDay;

        if (!mapCache.ContainsKey(name))
        {
            string latlng = _gisService.GetLatLng(name);
            if (!string.IsNullOrWhiteSpace(latlng))
                mapCache.TryAdd(name, latlng);
            else
                throw new Exception("Given Geo not found!");
        }
        var responseOn = DateTime.Now.TimeOfDay;
        return $"Geo:{name},Sent:{requestOn},Received:{responseOn},Response:{mapCache[name]}";
    }
}