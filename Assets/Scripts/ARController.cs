using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public GameObject Pubbles;
    public GameObject Almond;
    public ARRaycastManager RaycastManager;
    public ARPlaneManager plane;
    public ARPlane activeplane;
    public GameObject appearsound;

    private float nextActionTime = 0.0f;
    private int shortperiod = 10, longperiod = 35;
    private int count = 0, limit, elimit = 7, mlimit = 5, hlimit = 4;// spawn limits
    private int difficulty;
    private bool act;


    //get Random X within a range
    public float getRandomX()
    {
        float random;

        random = Random.Range(-1000, 3000);
        return random;
    }

    //get Random Z within a range //depth 
    public float getRandomZ()
    {
        float random;

        random = Random.Range(500, 900);
        return random;
    }

    //get Random Y within a range  
    public float getRandomY()
    {
        float random;

        random = Random.Range(-10, -20);
        return random;
    }


    //random Y for ROTATION
    public float randY()
    {
        float random = Random.Range(-110, -189);
        appearsound.SetActive(true);
        return random;
    }



    private void Start()
    {
        count++;
        appearsound.SetActive(false);

        plane = GetComponent<ARPlaneManager>();
        plane.planesChanged += PlaneChanged;

        //act = Timer.act;
        difficulty = DifficultyScript.levelint;//get the level value
        //set limit and spawn speed based on difficulty
        if (difficulty == 5)//easy
        {
            limit = elimit;
            shortperiod = 10;
            longperiod = 30;
        }
        if (difficulty == 4)//med
        {
            limit = mlimit;
            shortperiod = 15;
            longperiod = 45;
        }
        else //hard
        {
            limit = hlimit;
            shortperiod = 20;
            longperiod = 50;
        }
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null)
        {
           activeplane = args.added[0]; //save first plane detected
        }
    }


    // Update is called once per frame
    private void Update()
    {
        plane.planesChanged += PlaneChanged;

        //Random X, Z Spawn. Y remains 5 above plane
        Vector3 randomSpawn = new Vector3(getRandomX(), getRandomY(), getRandomZ());
        //Random Rotation
        Quaternion randomRot = new Quaternion(20, randY(), 3, 0);

        Vector3 appendtoPlanePos = new Vector3(getRandomX(), -20, 500);
        //ideal rand x, -20, 500

        if (count != limit)
        {
            //Goal is to set to 10 Seconds
            if (Time.time > nextActionTime)
            {
                nextActionTime = Time.time + shortperiod;
                //GameObject.Instantiate(Almond, randomSpawn, randomRot); // please see notes on trello card: Phone Tests
                GameObject.Instantiate(Almond, appendtoPlanePos += activeplane.transform.position, randomRot);

                count++;
            }


            ////Goal is to set to 15 Seconds
            //if (Time.time > nextActionTime)
            //{
            //    nextActionTime = Time.time + longperiod;
            //    //GameObject.Instantiate(Pubbles, randomSpawn, randomRot);
            //    GameObject.Instantiate(Pubbles, activeplane.transform.position, randomRot);
            //    count++;
            //}
        }

        ////OLD CONTROLS BASED ON TOUCH:
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    List<ARRaycastHit> touches = new List<ARRaycastHit>();
        //    RaycastManager.Raycast(Input.GetTouch(0).position, touches, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

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
