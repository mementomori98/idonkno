using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

    private GameObject player;
    private Rigidbody rb;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var dir = player.transform.position - transform.position;
        dir = dir.normalized;
        var rotation = Quaternion.LookRotation(dir);
        gameObject.transform.rotation = rotation;
        rb.velocity = dir * 15;
    }

    private void OnCollisionEnter(Collision other)
    {
        throw new NotImplementedException();
    }
}
