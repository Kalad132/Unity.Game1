using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _offset;
    [SerializeField] private float _speed; 

    private void Update()
    {
        var newPosition = transform.position;
        newPosition.x = Mathf.Lerp(transform.position.x, _player.transform.position.x + _offset, _speed);
        transform.position = newPosition;
    }
}
