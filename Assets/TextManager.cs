using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public static TextManager instance;

    public Text topLeft;
    public Text topRight;
    public Text bottomLeft;
    public Text bottomRight;
    public Text center;

    private void Awake()
    {
        instance = this;
        
        topLeft.text = "";
        topRight.text = "";
        bottomLeft.text = "";
        bottomRight.text = "";
        center.text = "";
    }

    public void SetTopLeft(string text)
    {
        topLeft.text = text;
    }
    public void SetTopRight(string text)
    {
        topRight.text = text;
    }
    public void SetBottomLeft(string text)
    {
        bottomLeft.text = text;
    }
    public void SetBottomRight(string text)
    {
        bottomRight.text = text;
    }
}
