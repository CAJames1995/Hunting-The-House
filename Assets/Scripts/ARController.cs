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
    public float shortperiod = 0.1f;
    public float longperiod = 0.2f;


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

        //Random X, Z Spawn. Y remains 5 above plane
        Vector3 randomSpawn = new Vector3(getRandomX(), 5, getRandomZ());


        //Goal is to set to 10 Seconds
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + shortperiod;
            GameObject.Instantiate(Almond, randomSpawn, Quaternion.identity);
        }


        //Goal is to set to 15 Seconds
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + longperiod;
            GameObject.Instantiate(Pubbles, randomSpawn, Quaternion.identity);
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
