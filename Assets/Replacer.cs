using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Replacer : MonoBehaviour
{

    public InputActionReference replace;

    private void Replace(InputAction.CallbackContext c)
    {
        gameObject.transform.position = Vector3.zero + Vector3.up * 20;
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
    }

    private void Awake()
    {
        replace.action.started += Replace;
    }

    private void OnDestroy()
    {
        replace.action.started -= Replace;
    }
}
