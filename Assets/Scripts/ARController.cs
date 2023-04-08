using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public GameObject Pubbles;
    public GameObject Almond;
    public ARRaycastManager RaycastManager;

    private float nextActionTime = 0.0f;
    private float shortperiod = 50000.0f;
    private float longperiod = 0.1f;
    private int s = 10, l = 35;
    private int count = 0, limit, elimit = 5, mlimit = 4, hlimit = 3;// spawn limits
    private int difficulty;
    private bool act;


    //get Random X within a range
    public float getRandomX()
    {
        float random;

        random = Random.Range(-10, 11);
        return random;
    }


    //get Random Z within a range //depth 
    public float getRandomZ()
    {
        float random;

        random = Random.Range(-10, 11);
        return random;
    }



    // Update is called once per frame
    private void Update()
    {
        //act = Timer.act;
        difficulty = DifficultyScript.levelint;//get the level value
        //set limit and spawn speed based on difficulty
        if (difficulty == 5)//easy
        {
            limit = elimit;
            s = 10;
            l = 30;
        }
        if (difficulty == 4)//med
        {
            limit = mlimit;
            s = 15;
            l = 45;
        }
        else //hard
        {
            limit = hlimit;
            s = 20;
            l = 50;
        }

        //Random X, Z Spawn. Y remains 5 above plane
        Vector3 randomSpawn = new Vector3(getRandomX(), 5, getRandomZ());

        if (count != limit)
        {
            //Goal is to set to 10 Seconds
            if (Time.time > nextActionTime)
            {
                //nextActionTime = Time.time + shortperiod;
                nextActionTime = Time.time + s;
                GameObject.Instantiate(Almond, randomSpawn, Quaternion.identity);
                count++;
            }


            //Goal is to set to 15 Seconds
            if (Time.time > nextActionTime)
            {
                //nextActionTime = Time.time + longperiod;
                nextActionTime = Time.time + l;
                GameObject.Instantiate(Pubbles, randomSpawn, Quaternion.identity);
                count++;
            }
        }




        //OLD CONTROLS BASED ON TOUCH:

        //if (Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    List<ARRaycastHit> touches = new List<ARRaycastHit>();
        //    RaycastManager.Raycast(Input.GetTouch(0).position,touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        //    if (touches.Count % 2 == 0)
        //    {
        //        GameObject.Instantiate(Pubbles, touches[0].pose.position, touches[0].pose.rotation);
        //    }
        //    else
        //    {
        //        GameObject.Instantiate(Almond, touches[0].pose.position, touches[0].pose.rotation);
        //    }
        //}


    }


}
