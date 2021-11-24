using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Replacer : MonoBehaviour
{

    public InputActionReference replace;
    public Vector3 position;

    private void Replace(InputAction.CallbackContext c)
    {
        gameObject.transform.position = position;
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        var enemies = GameObject.FindGameObjectsWithTag("monster");
        foreach (var e in enemies)
            Destroy(e);
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
