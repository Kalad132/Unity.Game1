using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private GameObject _groundTemplate;
    [SerializeField] private int _blockssAmount;
    [SerializeField] private Transform _player;
    [SerializeField] private float _updateDistance;

    private List<Transform> _grounds;

    private Vector3 _nextBlockPosition 
    { 
        get 
        {
            var result = new Vector3(0, transform.position.y, 0);
            if (_grounds.Count > 0)
            {
                Transform lastBlock = _grounds[_grounds.Count - 1];
                result.x = lastBlock.position.x + lastBlock.localScale.x;
            }
            return result;
        } 
    } 

    private void Start()
    {
        _grounds = new List<Transform>();
        for (var i=0; i < _blockssAmount; i++)
        {
            var newblock = Instantiate(_groundTemplate, _nextBlockPosition, Quaternion.identity, transform);
            _grounds.Add(newblock.transform);
        }
    }

    private void Update()
    {
        if (_player.position.x + _updateDistance > _nextBlockPosition.x)
        {
            MoveOldestBlock();
        }
    }

    private void MoveOldestBlock()
    {
        Transform block = _grounds[0];
        _grounds.RemoveAt(0);
        block.transform.position = _nextBlockPosition;
        _grounds.Add(block);
    }

}
