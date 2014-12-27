using System.Collections.Generic;
using System.Linq;

public class RouteNode
{
    public StarSystem Local;
    public Dictionary<RouteNode, float> Neighbors;

    public RouteNode Parent;
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

    public RouteNode(StarSystem local)
    {
        Local = local;
        Neighbors = null;
    }

    public void ComputeNeighbors(List<RouteNode> nodes, float jumpDistance)
    {
        Neighbors = new Dictionary<RouteNode, float>();
        foreach (RouteNode m in nodes)
        {
            if (this == m) { continue; }
            float distance = Local.Position.DistanceTo(m.Local.Position);
            if (distance <= jumpDistance)
            {
                Neighbors[m] = distance;
            }
        }
    }
}

public class RoutePlanner
{
    // WOW this needs to be an octree.  Like, the runtime's not bad, but FUCK is it inefficient
    private Dictionary<string, RouteNode> nodes;
    private List<RouteNode> openSet;
    private List<RouteNode> closedSet;
    private float jump;

    public RoutePlanner(List<StarSystem> systems, float jumpDistance)
    {
        nodes = new Dictionary<string, RouteNode>();
        foreach (StarSystem s in systems)
        {
            nodes[s.Name] = new RouteNode(s);
        }

        openSet = new List<RouteNode>();
        closedSet = new List<RouteNode>();

        jump = jumpDistance;
    }

    private void ClearRouteData()
    {
        openSet.Clear();
        closedSet.Clear();
        foreach (RouteNode node in nodes.Values)
        {
            node.TraversalCost = System.Single.PositiveInfinity;
            node.HScore = System.Single.PositiveInfinity;
            node.Parent = null;
            node.Open = false;
            node.Closed = false;
        }
    }

    public List<RouteNode> FindRoute(string startSystem, string endSystem)
    {
        ClearRouteData();

        RouteNode start = nodes[startSystem],
                  end = nodes[endSystem];

        AddToOpenSet(start, null, end, 0.0f);

        while (openSet.Count > 0)
        {
            // Take the node off the top of the open set and add it to the closed set
            RouteNode current = openSet[0];
            openSet.RemoveAt(0);
            current.Closed = true;

            if (current == end)
            {
                List<RouteNode> path = new List<RouteNode>();
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
            foreach (KeyValuePair<RouteNode,float> pair in current.Neighbors)
            {
                if (pair.Key.Closed) { continue; }
                AddToOpenSet(pair.Key, current, end, pair.Value);
            }
        }
        return null;
    }

    // Basically just keep the open list sorted.  Easier than going through every time and picking out the node with the cheapest G-Score
    private void AddToOpenSet(RouteNode node, RouteNode parent, RouteNode end, float cost)
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
        node.HScore = end.Local.Position.DistanceTo(node.Local.Position);

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