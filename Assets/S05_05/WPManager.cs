using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction { UNI, BI}
    [SerializeField] private GameObject _node1;
    [SerializeField] private GameObject _node2;
    [SerializeField] private direction _dir;

    public GameObject Node1 { get => _node1; set => _node1 = value; }
    public GameObject Node2 { get => _node2; set => _node2 = value; }
    public direction Dir { get => _dir; set => _dir = value; }
}

public class WPManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _waypoints;
    [SerializeField] private Link[] _links;
    private Graph _graph = new Graph();

    public Graph Graph { get => _graph; set => _graph = value; }
    public GameObject[] Waypoints { get => _waypoints; set => _waypoints = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (Waypoints.Length > 0)
        {
            foreach (GameObject wp in Waypoints)
            {
                Graph.AddNode(wp);
            }
            foreach(Link l in _links)
            {
                Graph.AddEdge(l.Node1, l.Node2);
                if(l.Dir == Link.direction.BI)
                {
                    Graph.AddEdge(l.Node2, l.Node1);
                }
            }
        }
    }
}
