using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKiller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        TextManager.instance.center.text = "Game Over";
        CountDown(4);
    }

    private async Task CountDown(int i)
    {
        await Task.Delay(1000);
        TextManager.instance.center.text = "Restarting in " + i;
        if (i > 0)
        {
            CountDown(i - 1);
        }
        else
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = Vector3.zero + Vector3.up * 14;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            var enemies = GameObject.FindGameObjectsWithTag("monster");
            foreach (var enemy in enemies)
                Destroy(enemy);
            TextManager.instance.center.text = "";
        }
    }
}
