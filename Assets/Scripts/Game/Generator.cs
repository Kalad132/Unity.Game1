using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _player;
    [SerializeField] private int _maxAmount;
    [SerializeField] private float _nextObjectSpawnDistance;
    [SerializeField] private float _distanceBetweenObjects;
    [SerializeField] private float _randomSpawnY;
    [SerializeField] private float _minSpawnY;
    [SerializeField] private float _maxSpawnY;

    private List<Transform> _objects;

    private void Awake()
    {
        _objects = new List<Transform>();
    }

    private void Update()
    {
        if (_player.position.x + _nextObjectSpawnDistance > GetNewPosition().x)
        {
            Spawn(GetNewPosition());
        }
    }

    private void Spawn(Vector3 position)
    {
        var newObject = Instantiate(_template, position, Quaternion.identity, transform);
        _objects.Add(newObject.transform);
        if (_objects.Count > _maxAmount)
            DestroyOldest();
    }

    private void DestroyOldest()
    {
        if (_objects[0] != null)
            Destroy(_objects[0].gameObject);
        _objects.RemoveAt(0);
    }

    private Vector3 GetNewPosition()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = GetLastPosition().x + _distanceBetweenObjects;
        spawnPosition.y = Mathf.Clamp(GetLastPosition().y + RandomY(), _minSpawnY, _maxSpawnY);
        return spawnPosition;
    }

    private Vector3 GetLastPosition()
    {
        if (_objects.Count > 0)
        {
            return _objects[_objects.Count - 1].position;
        }    
        else
        {
            var lastPosition = transform.position;
            lastPosition.x -= _distanceBetweenObjects;
            return lastPosition;
        }
    }

    private float RandomY()
    {
        return Random.Range(-_randomSpawnY, _randomSpawnY);
    }

}
