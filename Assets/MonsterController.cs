using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterController : MonoBehaviour
{

    private GameObject player;
    private Rigidbody rb;
    private PlayerKiller pk;
    private float speed;

    public bool dead;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        pk = GetComponent<PlayerKiller>();
        speed = Random.Range(7, 18);
    }

    void Update()
    {
        if (dead)
        {
            pk.disabled = true;
            return;
        }
        var dir = player.transform.position - transform.position;
        dir = dir.normalized;
        var rotation = Quaternion.LookRotation(dir);
        gameObject.transform.rotation = rotation;
        rb.velocity = dir * speed;
    }
}
