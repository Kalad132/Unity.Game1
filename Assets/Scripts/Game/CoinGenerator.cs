using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : Generator
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _RandomRangeSpawnY;
    [SerializeField] private float _minSpawnY;
    [SerializeField] private float _maxSpawnY;

    private float _spawnPositionX;
    private float lastPositonY;

    protected override Vector3 GetNewPosition()
    {
        Vector3 spawnPosition = new Vector3();
        spawnPosition.x = _spawnPositionX;
        spawnPosition.y = Mathf.Clamp(lastPositonY + Random.Range(-_RandomRangeSpawnY, _RandomRangeSpawnY), _minSpawnY, _maxSpawnY);
        lastPositonY = spawnPosition.y;
        return spawnPosition;
    }

    private void Update()
    {
        if ((_player.position.x + _spawnDistance) > _spawnPositionX)
        {
            Spawn(GetNewPosition());
            _spawnPositionX += 1;
        }
    }
}
