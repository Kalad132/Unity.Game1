using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _coinTemplate;
    [SerializeField] private float _spawnDistance;
    [SerializeField] private float _RandomRangeSpawnY;
    [SerializeField] private float _minSpawnY;
    [SerializeField] private float _maxSpawnY;
    [SerializeField] private int _maxCoinsAmount;

    private List<Transform> _coins;
    private float _spawnPositionX;
    private float lastPositonY;

    private void Start()
    {
        _coins = new List<Transform>();
        _spawnPositionX = 20;
    }

    private void Update()
    {
        if ((_player.position.x + _spawnDistance) > _spawnPositionX)
        {
            Vector3 spawnPosition = new Vector3();
            spawnPosition.x = _spawnPositionX;
            spawnPosition.y = Mathf.Clamp(lastPositonY + Random.Range(-_RandomRangeSpawnY, _RandomRangeSpawnY), _minSpawnY, _maxSpawnY);
            lastPositonY = spawnPosition.y;
            SpawnCoin(spawnPosition);
            _spawnPositionX += 1;
        }
    }

    private void SpawnCoin(Vector3 position)
    {
        var coin = Instantiate(_coinTemplate, position, Quaternion.identity, transform);
        _coins.Add(coin.transform);
        if (_coins.Count > _maxCoinsAmount)
            DestroyOldestCoin();
    }

    private void DestroyOldestCoin()
    {
        if (_coins[0] != null)
            Destroy(_coins[0].gameObject);
        _coins.RemoveAt(0);
    }
}
