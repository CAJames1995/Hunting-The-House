using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


/* Base code is from Gyanendu Shekhar and Comp-3 Interactive
 * 
 * Gyanendu Shekhar's Blog
 * blog title "Radial/ Circular Progress Bar in unity3d"
 * http://gyanendushekhar.com/2017/03/28/radial-circular-progress-bar-unity3d/
 * 
 * Comp-3 Interactive
 * found on youtube titled "How to Make Radial Progress Bars [Unity Tutorial]"
 * https://www.youtube.com/watch?v=emYjAOylbho
 * 
 * 
 * add source for timer DONT FORGET
 */

public class Timer : MonoBehaviour
{
    bool active = false, inside=false;
    float currentTime;
    public int startMins;
    public int score = 0;
    public int difficulty=5;
    public TMP_Text currentTimeText;
    public TMP_Text scoreText;
    public Image progBar;
    float currentValue=0;
    private readonly float speed = 1;
    private Collider coll;
    private Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = score.ToString();//set score label to score variable
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        difficulty = DifficultyScript.levelint;//get the level value
        currentTime = difficulty * 60;
        progBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                active= false;
                Start();
            }
            if (inside)
            {
                scoreText.text = "INSIDE COLLIDER";

                if (currentValue < 10)
                {
                    currentValue += speed * Time.deltaTime;
                    progBar.fillAmount = currentValue / 10;
                }
                else
                {
                    score += 1;
                    progBar.fillAmount = 0;
                    currentValue = 0;
                }

                progBar.fillAmount = currentValue / 10;
            }


        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        scoreText.text = score.ToString();
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


    private void OnCollisionEnter(Collision collision)
    {/*
        if(collision.gameObject)
        {
            inside = true;
            scoreText.text = "INSIDE COLLIDER";

            if (currentValue < 10)
            {
                currentValue += speed * Time.deltaTime;
                progBar.fillAmount = currentValue / 10;
            }
            else
            {
                score += 1;
                progBar.fillAmount = 0;
                currentValue = 0;
            }

            progBar.fillAmount = currentValue / 10;
        }*/
    }

    private void OnCollisionExit(Collision collision)
    {/*
        Debug.Log(collision.gameObject.name);
        currentValue = 0;
        progBar.fillAmount = 0;//reset when not inside
        inside= false;*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            inside = true;
            scoreText.text = "INSIDE COLLIDER";

            if (currentValue < 10)
            {
                currentValue += speed * Time.deltaTime;
                progBar.fillAmount = currentValue / 10;
            }
            else
            {
                score += 1;
                progBar.fillAmount = 0;
                currentValue = 0;
            }

            progBar.fillAmount = currentValue / 10;
            
        }
        if (other.gameObject.tag == "Patrick")
        {
            Debug.Log(other.gameObject.name);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        currentValue = 0;
        progBar.fillAmount = 0;//reset when not inside
        inside = false;

    }

}
