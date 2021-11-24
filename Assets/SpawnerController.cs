using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    public GameObject mob;

    private float time;
    private const float spawnDelay = 60.0f;

    void Update()
    {
        time += Time.deltaTime;
        if (time < spawnDelay)
            return;

        time -= spawnDelay;

        Instantiate(mob, transform);
    }
}
