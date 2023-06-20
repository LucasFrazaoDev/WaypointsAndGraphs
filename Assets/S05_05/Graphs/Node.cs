using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    [SerializeField] private List<Edge> edgeList = new List<Edge>();
    [SerializeField] private Node path = null;
    private GameObject id;

    public float f, g, h;
    public Node cameFrom;

    public List<Edge> EdgeList { get => edgeList; private set => edgeList = value; }
    public Node Path { get => path; private set => path = value; }

    public Node(GameObject i)
    {
        id = i;
        Path = null;
    }

    public GameObject getId() 
    { 
        return id;
    }
}
