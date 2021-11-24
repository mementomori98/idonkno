using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerController : MonoBehaviour
{

    public GameObject mob;

    private float time;
    private float spawnDelay;

    private void Awake()
    {
        spawnDelay = Random.Range(1, 10);
    }

    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if ((player.transform.position - transform.position).magnitude > 200)
            return;
        time += Time.deltaTime;
        if (time < spawnDelay)
            return;

        spawnDelay = Random.Range(6, 16);
        time = 0;

        Instantiate(mob, transform);
    }
}
