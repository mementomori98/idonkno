using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("bullet"))
            return;

        parent.transform.position = parent.transform.position + Vector3.up;
        Destroy(parent);
        Destroy(other.gameObject);
        Globals.instance.killCount += 1;
        TextManager.instance.SetTopLeft($"Kills: {Globals.instance.killCount}");
    }
}