using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterKiller : MonoBehaviour
{
    public GameObject parent;
    private bool dead;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire") && dead)
        {
            Destroy(parent);
        }
        if (!other.gameObject.CompareTag("bullet") || dead)
            return;

        dead = true;
        parent.GetComponent<MonsterController>().dead = true;
        parent.transform.rotation = Quaternion.LookRotation(Vector3.up);
        var rb = parent.GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * 8;
        rb.useGravity = true;
        Destroy(other.gameObject);
        Globals.instance.killCount += 1;
        TextManager.instance.SetTopLeft($"Kills: {Globals.instance.killCount}");
    }
    
}