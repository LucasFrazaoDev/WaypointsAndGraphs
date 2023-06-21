using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    [SerializeField] private List<Edge> _edgeList = new List<Edge>();
    [SerializeField] private Node _path = null;
    private GameObject _id;
    private float _f;
    private float _g;
    private float _h;
    private Node _cameFrom;

    public List<Edge> EdgeList { get => _edgeList; set => _edgeList = value; }
    public Node Path { get => _path; set => _path = value; }
    public float F { get => _f; set => _f = value; }
    public float G { get => _g; set => _g = value; }
    public float H { get => _h; set => _h = value; }
    public Node CameFrom { get => _cameFrom; set => _cameFrom = value; }

    public Node(GameObject i)
    {
        _id = i;
        Path = null;
    }

    public GameObject getId() 
    { 
        return _id;
    }
}
