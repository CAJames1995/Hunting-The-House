using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Timer : MonoBehaviour
{
    bool active = false;
<<<<<<< HEAD
=======
    bool inside=false;
>>>>>>> parent of d312d4a (meeting push)
    float currentTime;
    public int startMins;
    public TMP_Text currentTimeText;
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMins * 60;
=======
    public TMP_Text scoreText;
    public Image progBar;
    float currentValue=0;
    private readonly float speed = 1;
    public Component coll;
    public Rigidbody rb;
    


    // Start is called before the first frame update
    void Start()
    {

        scoreText.text = score.ToString();//set score label to score variable
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        difficulty = DifficultyScript.levelint;//get the level value
        currentTime = difficulty * 60;
        progBar.fillAmount = 0;
>>>>>>> parent of d312d4a (meeting push)
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
<<<<<<< HEAD
=======


>>>>>>> parent of d312d4a (meeting push)
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

<<<<<<< HEAD
=======

    private void OnCollisionEnter(Collision collision)
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

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        currentValue = 0;
        progBar.fillAmount = 0;//reset when not inside
        inside= false;

    }

>>>>>>> parent of d312d4a (meeting push)
}
