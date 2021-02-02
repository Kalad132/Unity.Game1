using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : Generator
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _updateDistance;

    protected override Vector3 GetNewPosition()
    {
        var result = new Vector3(0, transform.position.y, 0);
        if (_objects.Count > 0)
        {
            Transform lastBlock = _objects[_objects.Count - 1];
            result.x = lastBlock.position.x + lastBlock.localScale.x;
        }
        return result;
    }

    private void Update()
    {
        if (_player.position.x + _updateDistance > GetNewPosition().x)
        {
            Spawn(GetNewPosition());
        }
    }
}
