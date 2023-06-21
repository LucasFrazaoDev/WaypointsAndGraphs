using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    private Node _startNode;
    private Node _endNode;

    public Node StartNode { get => _startNode; set => _startNode = value; }
    public Node EndNode { get => _endNode; set => _endNode = value; }

    public Edge(Node from, Node to)
    {
        StartNode = from;
        EndNode = to;
    }
}
