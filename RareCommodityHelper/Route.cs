using System.Collections.Generic;
using System.Linq;
using System;

public class PathNode
{
    public StarSystem Local;
    public Dictionary<PathNode, float> Neighbors;

    public PathNode Parent;
    public float TraversalCost;
    public float HScore;
    public bool Open;
    public bool Closed;

    public float FScore { get { return GScore + HScore; } }
    public float GScore
    {
        get
        {
            return (Parent == null) ? TraversalCost : Parent.GScore + TraversalCost;
        }
    }

    public PathNode(StarSystem local)
    {
        Local = local;
        Neighbors = null;
    }

    public void ComputeNeighbors(List<PathNode> nodes, float jumpDistance)
    {
        Neighbors = new Dictionary<PathNode, float>();
        foreach (PathNode m in nodes)
        {
            if (this == m) { continue; }
            float distance = Local.Distance(m.Local);
            if (distance <= jumpDistance)
            {
                Neighbors[m] = distance;
            }
        }
    }
}

public class PathPlanner
{
    // WOW this needs to be an octree.  Like, the runtime's not bad, but FUCK is it inefficient
    private Dictionary<string, PathNode> nodes;
    private List<PathNode> openSet;
    private List<PathNode> closedSet;
    private float jump;

    public PathPlanner(List<StarSystem> systems, float jumpDistance)
    {
        nodes = new Dictionary<string, PathNode>();
        foreach (StarSystem s in systems)
        {
            nodes[s.Name] = new PathNode(s);
        }

        openSet = new List<PathNode>();
        closedSet = new List<PathNode>();

        jump = jumpDistance;
    }

    private void ClearPathData()
    {
        openSet.Clear();
        closedSet.Clear();
        foreach (PathNode node in nodes.Values)
        {
            node.TraversalCost = System.Single.PositiveInfinity;
            node.HScore = System.Single.PositiveInfinity;
            node.Parent = null;
            node.Open = false;
            node.Closed = false;
        }
    }

    public List<PathNode> FindPath(string startSystem, string endSystem)
    {
        ClearPathData();

        PathNode start = nodes[startSystem],
                  end = nodes[endSystem];

        AddToOpenSet(start, null, end, 0.0f);

        while (openSet.Count > 0)
        {
            // Take the node off the top of the open set and add it to the closed set
            PathNode current = openSet[0];
            openSet.RemoveAt(0);
            current.Closed = true;

            if (current == end)
            {
                List<PathNode> path = new List<PathNode>();
                while (current != null)
                {
                    path.Insert(0, current);
                    current = current.Parent;
                }
                return path;
            }

            // Add its neighbors to the open list
            if (current.Neighbors == null)
            {
                current.ComputeNeighbors(nodes.Values.ToList(), jump);
            }
            foreach (KeyValuePair<PathNode,float> pair in current.Neighbors)
            {
                if (pair.Key.Closed) { continue; }
                AddToOpenSet(pair.Key, current, end, pair.Value);
            }
        }
        return null;
    }

    // Basically just keep the open list sorted.  Easier than going through every time and picking out the node with the cheapest G-Score
    private void AddToOpenSet(PathNode node, PathNode parent, PathNode end, float cost)
    {
        float newGScore = (parent == null) ? cost : (parent.GScore + cost);
        if (node.Open)
        {
            if (node.GScore <= newGScore) { return; }
            openSet.Remove(node);
        }

        node.Open = true;
        node.Parent = parent;
        node.TraversalCost = cost;
        node.HScore = end.Local.Distance(node.Local);

        for (int i = 0; i < openSet.Count; i++)
        {
            if (openSet[i].FScore >= node.FScore)
            {
                openSet.Insert(i, node);
                return;
            }
        }
        openSet.Add(node);
    }
}

class RouteNode
{
    public RareGood Rare;
    public Coords Position;
    public float DistanceFromPlane;
    public float DistanceFromPrev;
    public float DistanceFromNext;
    public float DistanceFromSphere;
    public float DistanceFromCross;

    public float SortingMetric;
    public RouteNode(RareGood r, Coords center, Coords radiusNormal, Coords radiusPoint, RareGood prev, RareGood next, RareGood cross, float ideal)
    {
        Rare = r;
        Position = r.Location.Position;
        DistanceFromSphere = Position.Distance(center);
        DistanceFromPrev = Rare.Distance(prev);
        DistanceFromPlane = (radiusNormal.X * (Position.X - radiusPoint.X)) + (radiusNormal.Y * (Position.Y - radiusPoint.Y)) + (radiusNormal.Z * (Position.Z - radiusPoint.Z));

        SortingMetric = DistanceFromSphere + DistanceFromPrev + DistanceFromPlane;
        if (next != null)
        {
            DistanceFromNext = Rare.Distance(next);
            SortingMetric += DistanceFromNext;
        }
        if (cross != null)
        {
            DistanceFromCross = Math.Abs(ideal - Rare.Distance(cross));
            SortingMetric += DistanceFromCross;
        }
    }
}

public class RoutePlanner
{
    private const float Pi = 3.14159f;
    private const float TwoPi = Pi * 2.0f;
    private Dictionary<string, RareGood> nodes;

    public RoutePlanner(List<StarSystem> systems, List<RareGood> rares, float jumpDistance)
    {
        foreach(RareGood rare in rares)
        {
            nodes.Add(rare.LocationName, rare);
        }
    }

    public List<RareGood> FindRoute(string currentSystem, float idealDistance, int jumpsPerLeg, int attempts)
    {
        float sellDistance = idealDistance;
        RareGood startingGood = nodes[currentSystem];

        List<RareGood> ret = null;
        for(int i = 0; i < attempts; i++)
        {
            if(AttemptRoute(startingGood, idealDistance, jumpsPerLeg, out ret))
            {
                break;
            }
        }
        return ret;
    }

    public bool AttemptRoute(RareGood startingGood, float idealDistance, int jumpsPerLeg, out List<RareGood> route)
    {
        // Select the good that is closest to and above the ideal distance from the starting point
        RareGood midGood = nodes.Values.Where(r => startingGood.Location.Distance(r.Location) >= idealDistance).OrderBy(r => startingGood.Location.Distance(r.Location)).FirstOrDefault();

        // Describe a sphere that contains both the starting good and mid good
        Coords halfOffset = (midGood.Location.Position - startingGood.Location.Position) / 2.0f;
        Coords center = startingGood.Location.Position + halfOffset;

        // Cull any nodes inside the sphere
        float idealSquared = idealDistance * idealDistance;
        List<RareGood> viableNodes = nodes.Values.Where(r => startingGood.Location.Position.DistanceSquared(center) > idealSquared).ToList();

        Coords radiusDir = halfOffset.Normal();
        float radius = halfOffset.Magnitude();
        float arcLength = radius * Pi;
        float idealStep = arcLength / jumpsPerLeg;

        // Prepare initial state
        viableNodes.Remove(startingGood);
        viableNodes.Remove(midGood);

        List<RareGood> potentialRoute = new List<RareGood>();
        potentialRoute.Add(startingGood);
        RareGood prev = startingGood;

        for(int i = 1; i < jumpsPerLeg * 2; i++)
        {
            if (i == jumpsPerLeg)
            {
                prev = midGood;
                potentialRoute.Add(midGood);
                continue;
            }

            float distanceFromCenter = -radius * (float)Math.Sin(Pi * (((float)i / jumpsPerLeg) + 0.5f));
            Coords pointAlongDiameter = center + (halfOffset * distanceFromCenter);

            RareGood next = null;
            if (i == jumpsPerLeg - 1) { next = midGood; }
            else if (i == jumpsPerLeg * 2 - 1) { next = startingGood; }
            RareGood cross = (i > jumpsPerLeg) ? potentialRoute[i - jumpsPerLeg] : null;
            List<RouteNode> viableRoutes = viableNodes.Select(n => new RouteNode(n, center, radiusDir, pointAlongDiameter, prev, next, cross, idealDistance)).ToList();
            viableRoutes.Sort(delegate(RouteNode x, RouteNode y) {
                return x.SortingMetric > y.SortingMetric ? 1 : -1;
            });

            prev = viableRoutes.FirstOrDefault().Rare;
            potentialRoute.Add(prev);
            viableNodes.Remove(prev);
        }

        route = potentialRoute;
        return true;
    }
}