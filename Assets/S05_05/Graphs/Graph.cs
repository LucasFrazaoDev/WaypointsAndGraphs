using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private List<Edge> edges = new List<Edge>();
    private List<Node> nodes = new List<Node>();
    [SerializeField] private List<Node> pathList = new List<Node>();

    public List<Node> PathList { get => pathList; private set => pathList = value; }

    public Graph() { }

    public void AddNode(GameObject id)
    {
        Node node = new Node(id);
        nodes.Add(node);
    }

    public void AddEdge(GameObject fromNode, GameObject toNode)
    {
        Node from = FindNode(fromNode);
        Node to = FindNode(toNode);

        if (from != null && to != null)
        {
            Edge e = new Edge(from, to);
            edges.Add(e);
            from.EdgeList.Add(e);
        }
    }

    private Node FindNode(GameObject id)
    {
        foreach (Node n in nodes)
        {
            if(n.getId() == id)
                return n;
        }
        return null;
    }

    public bool AStar(GameObject startId, GameObject endId)
    {
        if (startId == endId)
        {
            PathList.Clear();
            return false;
        }

        Node start = FindNode(startId);
        Node end = FindNode(endId);

        if (start == null || end == null)
            return false;

        List<Node> open = new List<Node>();
        List<Node> closed = new List<Node>();
        float tentativeGScore = 0;
        bool tentativeIsBetter;

        start.g = 0;
        start.h = Distance(start, end);
        start.f = start.h;

        open.Add(start);

        while (open.Count > 0)
        {
            int i = LowestF(open);
            Node thisNode = open[i];
            if(thisNode.getId() == endId)
            {
                ReconstructPath(start, end);
                return true;
            }

            open.RemoveAt(i);
            closed.Add(thisNode);
            Node neighbour; // Nó vizinho ao atual

            foreach (Edge e in thisNode.EdgeList)
            {
                neighbour = e.EndNode;

                if (closed.IndexOf(neighbour) > -1)
                    continue;

                tentativeGScore = thisNode.g + Distance(thisNode, neighbour);
                if(open.IndexOf(neighbour) == -1)
                {
                    open.Add(neighbour);
                    tentativeIsBetter = true;
                }
                else if(tentativeGScore < neighbour.g)
                {
                    tentativeIsBetter = true;
                }
                else
                {
                    tentativeIsBetter = false;
                }

                if(tentativeIsBetter)
                {
                    neighbour.cameFrom = thisNode;
                    neighbour.g = tentativeGScore;
                    neighbour.h = Distance(neighbour, end);
                    neighbour.f = neighbour.g + neighbour.h;
                }
            }
        }
        return false;
    }

    public void ReconstructPath(Node startId, Node endId)
    {
        PathList.Clear();
        PathList.Add(endId);

        var p = endId.cameFrom;
        while (p != startId && p != null)
        {
            PathList.Insert(0, p);
            p = p.cameFrom;
        }
        PathList.Insert(0, startId);
    }

    private float Distance(Node a, Node b)
    {
        return Vector3.SqrMagnitude(a.getId().transform.position - b.getId().transform.position);
    }

    private int LowestF(List<Node> nodes)
    {
        float lowestF = 0;
        int count = 0;
        int iteratorCount = 0;

        lowestF = nodes[0].f;

        for (int i = 1; i < nodes.Count; i++)
        {
            if (nodes[i].f < lowestF)
            {
                lowestF = nodes[i].f;
                iteratorCount = count;
            }
            count++;
        }
        return iteratorCount;
    }
}
