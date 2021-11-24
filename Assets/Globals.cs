using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static Globals instance;
    
    public int killCount;

    private void Awake()
    {
        instance = this;
    }
}
