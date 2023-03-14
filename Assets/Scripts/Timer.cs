using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    bool active = false;
    float currentTime;
    public int startMins;
    public TMP_Text currentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMins * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                active= false;
                Start();
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString()+":" + time.Seconds.ToString();
    }
    public void StartTimer()
    {   
        active= true;
    }
    public void StopTimer()
    {
        active= false;
    }

}
