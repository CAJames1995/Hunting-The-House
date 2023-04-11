using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Security.Cryptography;
using System.Threading;


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
    bool active = false, inside=false, isPaused;
    public static bool act;
    public float currentTime, cdtimer = 0.0f;
    public int startMins;
    public int score = 0, catchtime= 10;
    public static int s1 = 0, s2=0, s3=0;
    public static int difficulty=5;
    public TMP_Text currentTimeText;
    public TMP_Text scoreText;
    //public TMP_Text gameover;
    public Image progBar;
    float currentValue=0;
    private readonly float speed = 1;
    private Collider coll;
    private Rigidbody rb;
    public GameObject pause;
    public Sprite playicon, pauseicon;
    public GameObject gameoverScreen;
    public TMP_Text finalScore;
    public GameObject countdown;
    public int count = 0;
    public GameObject huntPrompt;
    public GameObject barkSound;

    //public bool isPlayerStarted;
    //public double playtime;

    // Start is called before the first frame update
    void Start()
    {
        //isPlayerStarted = false; 
        isPaused = false;
        pauseicon = Resources.Load<Sprite>("PauseBttn");
        playicon = Resources.Load<Sprite>("PlayBttn");
        gameoverScreen.SetActive(false);
        huntPrompt.SetActive(false);
        barkSound.SetActive(false);

        //play.SetActive(false); //play button object is invisible
        //pause.SetActive(true); //pause button object is visible
        scoreText.text = score.ToString();//set score label to score variable
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        difficulty = DifficultyScript.levelint;//get the level value
        currentTime = difficulty * 60;
        progBar.fillAmount = 0;

        //adjust catch time based on difficulty
        if (difficulty == 5)//easy
        {
            catchtime = 5;
        }else if (difficulty == 4)//med
        {
            catchtime = 7;
        }else{//hard
            catchtime = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //COUNTDOWN 3 SECONDS, STARTS GAME ON 3rd SECOND
        cdtimer = Time.timeSinceLevelLoad; ;
        count = (int)(cdtimer % 60);

        if (count == 3)
        {
            active = true; //START
            currentTime = difficulty * 60; //reset current time
            countdown.SetActive(false);
            huntPrompt.SetActive(true);
            barkSound.SetActive(true);
        }

        ////also try:
        //if (countdown.isPlaying == false)
        //{

        //}

        //playtime = countdown.GetComponent<VideoPlayer>().clip.length;


        if (count == 5)
        {
            huntPrompt.SetActive(false);
        }


        if (active)
        {
            currentTime -= Time.deltaTime;
            //if (currentTime <= 0)
            //{
            //    ();
            //}
            if (inside)
            {

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
                    if (difficulty == 5)//easy
                        s1 = score;
                    else if (difficulty == 4)//medium
                        s2 = score;
                    else //hard
                        s3 = score;
                }

                progBar.fillAmount = currentValue / catchtime;
            }


        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        scoreText.text = score.ToString();
        currentTimeText.text = time.Minutes.ToString()+":" + time.Seconds.ToString();

        if (currentTimeText.text == "0:0")
        {
            gameoverScreen.SetActive(true);
            finalScore.text = score.ToString();
            active = false;
        }

    }


    public void Pause()
    {
        if (isPaused)
        {//if paused, unpause:
            active = true;
            isPaused = false;

            pause.GetComponent<Image>().sprite = pauseicon;
        }
        else
        {//pause: 
            active = false;
            isPaused = true;

            pause.GetComponent<Image>().sprite = playicon;

        }
        act = active;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            inside = true;

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
                //Destroy(other.gameObject);
            }

            progBar.fillAmount = currentValue / 10;

        }
        //if (other.gameObject.tag == "Almond" || other.gameObject.tag == "Pubbles")
        //if (other.gameObject.tag == "Patrick")
        if (other.gameObject.CompareTag("Patrick"))
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
