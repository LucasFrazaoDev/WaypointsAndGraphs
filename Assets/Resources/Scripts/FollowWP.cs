using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    private Transform _goal;
    private float _speed = 8.0f;
    private float _accuracy = 5.0f;
    private float _rotSpeed = 2.5f;

    [SerializeField] private GameObject _wpManager;
    [SerializeField] private GameObject[] _wps;
    private GameObject _currentNode;
    private int _currentWP = 0;
    private Graph _graph;

    // Events and delegates for SFX e VFX
    public delegate void TankMoving();
    public event TankMoving OnTankMoving;

    public delegate void TankStopped();
    public event TankStopped OnTankStopped;

    private void Start()
    {
        _wps = _wpManager.GetComponent<WPManager>().Waypoints;
        _graph = _wpManager.GetComponent<WPManager>().Graph;
        _currentNode = _wps[0];
    }

    private void LateUpdate()
    {
        if (_graph.PathList.Count == 0 || _currentWP == _graph.PathList.Count)
            return;

        DistanceToNode();
        Move();
    }

    private void DistanceToNode()
    {
        if (Vector3.Distance(_graph.PathList[_currentWP].getId().transform.position, transform.position) < _accuracy)
        {
            _currentNode = _graph.PathList[_currentWP].getId();
            _currentWP++;
        }
    }

    private void Move()
    {
        if (_currentWP < _graph.PathList.Count)
        {
            _goal = _graph.PathList[_currentWP].getId().transform;
            Vector3 lookAtGoal = new Vector3(_goal.position.x, transform.position.y, _goal.position.z);
            Vector3 direction = lookAtGoal - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotSpeed);

            transform.Translate(0, 0, _speed * Time.deltaTime);

            // Dispara o evento OnTankMoving quando o tanque está se movendo
            if (OnTankMoving != null)
            {
                OnTankMoving.Invoke();
            }
        }
        else
        {
            // Dispara o evento OnTankStopped quando o tanque parou de se mover
            if (OnTankStopped != null)
            {
                OnTankStopped.Invoke();
            }
        }
    }

    public void GoToDestination(int destinationIndex)
    {
        // Verifica se o tanque já está em movimento
        if (_currentWP < _graph.PathList.Count)
            return;

        switch (destinationIndex)
        {
            case 0: // Heli
                _graph.AStar(_currentNode, _wps[destinationIndex]);
                _currentWP = 0;
                break;
            case 7: // Ruin
                _graph.AStar(_currentNode, _wps[destinationIndex]);
                _currentWP = 0;
                break;
            case 2: // Factory
                _graph.AStar(_currentNode, _wps[destinationIndex]);
                _currentWP = 0;
                break;
            case 5: // OilField
                _graph.AStar(_currentNode, _wps[destinationIndex]);
                _currentWP = 0;
                break;
            default:
                Debug.LogError("Destination index not recognized.");
                break;
        }
    }
}
