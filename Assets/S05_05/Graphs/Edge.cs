using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    private Node startNode;
    private Node endNode;

    public Node StartNode { get => startNode; set => startNode = value; }
    public Node EndNode { get => endNode; set => endNode = value; }

    public Edge(Node from, Node to)
    {
        StartNode = from;
        EndNode = to;
    }
}
