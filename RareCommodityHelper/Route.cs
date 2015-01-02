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

public class RouteNode
{
    public RareGood Rare;
    public List<RareGood> SellHere;

    public RouteNode(RareGood r)
    {
        Rare = r;
        SellHere = new List<RareGood>();
    }

    public RouteNode(RareGood r, List<RareGood> sell)
    {
        Rare = r;
        SellHere = new List<RareGood>(sell);
    }
}

public class RoutePlanner
{
    private const float Pi = 3.14159f;
    private const float TwoPi = Pi * 2.0f;
    private List<RareGood> rares;

    public RoutePlanner(List<RareGood> r, float jumpDistance)
    {
        rares = r;
    }

    public List<RouteNode> FindRoute(StarSystem currentSystem, float idealDistance, int jumpsPerLeg, int maxJumps)
    {
        RareGood closest = rares.OrderBy(r => currentSystem.Distance(r.Location)).FirstOrDefault();

        List<RouteNode> route = new List<RouteNode>();
        route.Add(new RouteNode(closest));
        List<RareGood> currentRares = new List<RareGood>();

        while (route.Count < maxJumps)
        {
            RareGood current = route[route.Count - 1].Rare;
            currentRares.Add(current);
            RareGood next = rares.Where(delegate(RareGood r) {
                // Check to see if we've already visited this location in this leg
                if (currentRares.Contains(r)) { return false; }

                // Check to see if this step is inefficient in the scope of the leg
                float distance = current.Distance(r);
                if (distance > idealDistance) { return false; }
                r.Fitness = distance;

                // Check to see if we have to sell here
                float sellOffsets = 0.0f;
                bool canSell = false;
                foreach(RareGood s in currentRares)
                {
                    float toSeller = s.Distance(r);
                    if (toSeller >= idealDistance) { canSell = true; }
                    sellOffsets -= (toSeller - idealDistance);
                }
                if (currentRares.Count == jumpsPerLeg && !canSell)
                {
                    return false;
                }
                r.Fitness += sellOffsets / 10.0f;

                // This rare is valid
                return true;
            }).OrderBy(r => r.Fitness).FirstOrDefault();
            if (next == null) { break; }
            List<RareGood> sellable = new List<RareGood>();
            foreach (RareGood r in currentRares)
            {
                if (next.Distance(r) >= idealDistance) { sellable.Add(r); }
            }
            foreach (RareGood r in sellable)
            {
                currentRares.Remove(r);
            }
            route.Add(new RouteNode(next, sellable));
        }

        return route;
    }
}