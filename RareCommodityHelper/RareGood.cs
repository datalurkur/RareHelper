using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

public class StarSystem
{
    public string Name = "";
    public Coords Position = new Coords();

    public float Distance(StarSystem other)
    {
        return Position.Distance(other.Position);
    }

    public string PhoenicName()
    {
        return BIG_NUMBER_REGEX.Replace(Name, new MatchEvaluator(SeparateDigits));
    }

    private static Regex BIG_NUMBER_REGEX = new Regex("\\d{3,}");
    private string SeparateDigits(Match m)
    {
        var s = new StringBuilder();
        foreach (var ch in m.Value) {
            if (s.Length > 0) s.Append("; ");  // This adds a pause.
            s.Append(ch);
        }
        return s.ToString();
    }
}

public class Destination
{
    public RareGood Rare = null;
    public float Distance = 0.0f;
}

public class RareGood
{
    public string Name;
    public string LocationName;
    public string Station;
    public string StationDistance;
    public string Allegiance;
    public int LastKnownCost;

    [XmlIgnoreAttribute]
    public StarSystem Location;

    [XmlIgnoreAttribute]
    public float Fitness;

    public RareGood()
    {
        Name = "";
        LocationName = "";
        Station = "";
        StationDistance = "";
        Allegiance = "";
        LastKnownCost = 0;
        Fitness = Single.PositiveInfinity;

        Location = null;
    }

    public RareGood(string location, string station, string name)
    {
        Name = name;
        LocationName = location;
        Station = station;
    }

    public float Distance(RareGood other)
    {
        return Location.Position.Distance(other.Location.Position);
    }

    private static Regex DISTANCE_REGEX = new Regex("(\\d+)ls");
    public float StationDistanceInLightSeconds()
    {
        var m = DISTANCE_REGEX.Match(StationDistance);
        if (!m.Success) return -1;
        return float.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
    }
}

public class Galaxy
{
    public Dictionary<string,StarSystem> Systems { get; private set; }

    public Galaxy()
    {
        Systems = new Dictionary<string,StarSystem>();
    }

    public async Task GetData()
    {
        Systems = await StarCoordinator.FetchSystems();
    }

    public void SortRaresByDistance(string sourceName, List<RareGood> rares, out List<Destination> sortedSystems)
    {
        StarSystem source = this.Systems[sourceName];
        sortedSystems = new List<Destination>();
        foreach(RareGood rare in rares)
        {
            Destination destination = new Destination();
            destination.Rare = rare;
            destination.Distance = source.Distance(rare.Location);
            sortedSystems.Add(destination);
        }
        sortedSystems.Sort(delegate (Destination x, Destination y) { return (x.Distance > y.Distance) ? 1 : -1; });
    }
}