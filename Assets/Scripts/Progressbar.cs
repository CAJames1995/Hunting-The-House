using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System;
using UnityEngine;
using UnityEngine.UI;

/* Base code is from Gyanendu Shekhar and Comp-3 Interactive
 * 
 * Gyanendu Shekhar's Blog
 * blog title "Radial/ Circular Progress Bar in unity3d"
 * http://gyanendushekhar.com/2017/03/28/radial-circular-progress-bar-unity3d/
 * 
 * Comp-3 Interactive
 * found on youtube titled "How to Make Radial Progress Bars [Unity Tutorial]"
 * https://www.youtube.com/watch?v=emYjAOylbho
 */

public class Progressbar : MonoBehaviour
{
    public GameObject pubbles, almond;
    public Image progBar;
    float currentValue;
    private readonly float speed=1;
    private Component coll;

    // Use this for initialization
    void Start()
    {
        coll= GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
    /*
    if (currentValue < 10)
    {
        currentValue += speed * Time.deltaTime;
    }
    else
    {
    }*/ 

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (coll)
        {

            if (currentValue < 10)
            {
                currentValue += speed * Time.deltaTime;
                progBar.fillAmount = currentValue / 10;
            }
        }

        progBar.fillAmount = currentValue / 10;
    }

    private void OnCollisionExit(Collision collision)
    {
    
        currentValue = 0;
        progBar.fillAmount = 0;//reset when not inside
            
    }
}

