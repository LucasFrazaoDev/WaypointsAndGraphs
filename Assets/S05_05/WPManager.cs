using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum direction { UNI, BI}
    [SerializeField] GameObject node1;
    [SerializeField] GameObject node2;
    [SerializeField] direction dir;

    public GameObject Node1 { get => node1; private set => node1 = value; }
    public GameObject Node2 { get => node2; private set => node2 = value; }
    public direction Dir { get => dir; private set => dir = value; }
}

public class WPManager : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private Link[] links;
    private Graph graph = new Graph();

    public Graph Graph { get => graph; set => graph = value; }
    public GameObject[] Waypoints { get => waypoints; set => waypoints = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (Waypoints.Length > 0)
        {
            foreach (GameObject wp in Waypoints)
            {
                Graph.AddNode(wp);
            }
            foreach(Link l in links)
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
