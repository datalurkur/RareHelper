using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class Coords
{
    public float X = 0.0f;
    public float Y = 0.0f;
    public float Z = 0.0f;

    public float DistanceTo(Coords other)
    {
        float xDiff = this.X - other.X,
              yDiff = this.Y - other.Y,
              zDiff = this.Z - other.Z;
        return (float)System.Math.Sqrt((xDiff * xDiff) + (yDiff * yDiff) + (zDiff * zDiff));
    }
}

public class StarSystem
{
    public string Name = "";
    public Coords Position = new Coords();
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

    public RareGood()
    {
        Name = "";
        LocationName = "";
        Station = "";
        StationDistance = "";
        Allegiance = "";
        LastKnownCost = 0;

        Location = null;
    }

    public RareGood(string location, string station, string name)
    {
        Name = name;
        LocationName = location;
        Station = station;
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
            destination.Distance = source.Position.DistanceTo(rare.Location.Position);
            sortedSystems.Add(destination);
        }
        sortedSystems.Sort(delegate (Destination x, Destination y) { return (x.Distance > y.Distance) ? 1 : -1; });
    }
}