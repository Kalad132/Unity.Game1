using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    private int _score;

    public UnityAction<int> ScoreChanged;

    private void Awake()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            AddScore();
            Destroy(coin.gameObject);
        }
    }

    private void AddScore()
    {
        _score += 1;
        ScoreChanged?.Invoke(_score);
    }
}