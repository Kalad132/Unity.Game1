using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityAction Jump;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump?.Invoke();
        }
    }
}
