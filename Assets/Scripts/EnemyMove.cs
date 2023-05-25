using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _distanceToPlayer;
    [SerializeField] private Transform _player;
    [SerializeField] private float _distanceToWaypoints;

    private int _currentWaypointIndex;
    private bool _playerInRange;

    private void Start()
    {
        _currentWaypointIndex = 0;
        _playerInRange = false;
    }

    private void Update()
    {
        if (!_playerInRange)
        {
            Patrol();
        }
        else
        {
            Chase();
        }
    }

    private void Patrol()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypointIndex].position, step);

        if (Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].position) < _distanceToWaypoints)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }

        if (Vector3.Distance(transform.position, _player.position) < _distanceToPlayer)
        {
            _playerInRange = true;
        }
    }

    private void Chase()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _player.position, step);

        if (Vector3.Distance(transform.position, _player.position) > _distanceToPlayer)
        {
            _playerInRange = false;
        }
    }
}

