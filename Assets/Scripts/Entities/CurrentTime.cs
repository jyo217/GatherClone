using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentTime : MonoBehaviour
{
    private Text currentTime;

    // Start is called before the first frame update
    private void Start()
    {
        currentTime = GameObject.Find("TimeUI").GetComponent<Text>();        
    }

    // Update is called once per frame
    private void Update()
    {
        currentTime.text = GetCurrentTime();
    }

    private string GetCurrentTime()
    {
        return DateTime.Now.ToString("HH : mm");
    }
}
