using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : Generator
{
    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _spawnPeriod;
    [SerializeField] private float _spawnPeriodRandom;
    [SerializeField] private Transform _player;

    private float _spawnTrigger;

    protected override Vector3 GetNewPosition()
    {
        return new Vector3(_player.position.x + _spawnDistance, transform.position.y, 0);
    }

    private void Update()
    {
        if (_player.position.x > _spawnTrigger)
        {
            Spawn(GetNewPosition());
            UpdateSpawnTrigger();
        }
    }

    private void UpdateSpawnTrigger()
    {
        _spawnTrigger = _player.position.x + _spawnPeriod + Random.Range(-_spawnPeriodRandom, _spawnPeriodRandom);
    }

}
