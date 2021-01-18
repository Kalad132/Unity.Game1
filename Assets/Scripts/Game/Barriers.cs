using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{
    [SerializeField] private GameObject _barrierTemplate;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _spawnPeriod;
    [SerializeField] private float _spawnPeriodRandom;
    [SerializeField] private Transform _player;
    [SerializeField] private int _maxBarriers;

    private float _spawnTrigger;
    private List<Transform> _barriers;

    private void Start()
    {
        _barriers = new List<Transform>();
    }

    private void Update()
    {
        if (_player.position.x > _spawnTrigger)
        {
            SpawnBarrier();
            UpdateSpawnTrigger();
        }
    }

    private void UpdateSpawnTrigger()
    {
        _spawnTrigger = _player.position.x + _spawnPeriod + Random.Range(-_spawnPeriodRandom, _spawnPeriodRandom);
    }

    private void SpawnBarrier()
    {
        _barriers.Add(CreateBarrier().transform);
        if (_barriers.Count == _maxBarriers)
        {
            Destroy(_barriers[0].gameObject);
            _barriers.RemoveAt(0);
        }
    }

    private Transform CreateBarrier()
    {
        var newBarrier =  Instantiate(_barrierTemplate, new Vector3(_player.position.x + _spawnDistance, transform.position.y, 0), Quaternion.identity, transform);
        return newBarrier.transform;
    }

}
