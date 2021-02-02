using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private int _maxAmount;

    protected List<Transform> _objects;

    protected abstract Vector3 GetNewPosition();

    private void Awake()
    {
        _objects = new List<Transform>();
    }
    protected void Spawn(Vector3 position)
    {
        var newObject = Instantiate(_template, position, Quaternion.identity, transform);
        _objects.Add(newObject.transform);
        if (_objects.Count > _maxAmount)
            DestroyOldest();
    }

    protected void DestroyOldest()
    {
        if (_objects[0] != null)
            Destroy(_objects[0].gameObject);
        _objects.RemoveAt(0);
    }
}
