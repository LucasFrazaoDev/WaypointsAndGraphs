using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    private Transform goal;
    private float speed = 8.0f;
    private float accuracy = 5.0f;
    private float rotSpeed = 2.0f;

    [SerializeField] private GameObject wpManager;
    [SerializeField] private GameObject[] wps;
    private GameObject currentNode;
    private int currentWP = 0;
    private Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        wps = wpManager.GetComponent<WPManager>().Waypoints;
        graph = wpManager.GetComponent<WPManager>().Graph;
        currentNode = wps[0];

        //Invoke("GoToRuin", 3f);
    }

    public void GoToHeli()
    {
        graph.AStar(currentNode, wps[0]);
        currentWP = 0;
    }

    public void GoToRuin()
    {
        graph.AStar(currentNode, wps[7]);
        currentWP = 0;
    }

    public void GoToFactory()
    {
        graph.AStar(currentNode, wps[2]);
        currentWP = 0;
    }

    void LateUpdate()
    {
        if (graph.PathList.Count == 0 || currentWP == graph.PathList.Count)
            return;

        if (Vector3.Distance(graph.PathList[currentWP].getId().transform.position, transform.position) < accuracy)
        {
            currentNode = graph.PathList[currentWP].getId();
            currentWP++;
        }

        if (currentWP < graph.PathList.Count)
        {
            goal = graph.PathList[currentWP].getId().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);

            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
