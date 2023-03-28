using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoresScript : MonoBehaviour
{

    [SerializeField] TMP_Text e1, m1, h1;
    private static int hunt_e = 0, hunt_m = 0, hunt_h = 0;// house_e=0, house_m=0, house_h=0;
    private int score1, score2, score3;
    // Start is called before the first frame update
    void Start()
    {


    }

  

    private void Update()
    {
        score1 = Timer.s1;
        score2 = Timer.s2;
        score3 = Timer.s3;

        //Hunt Mode Scoring
        //easy mode
        if (hunt_e < score1)
        {
            hunt_e = score1;
            e1.text= hunt_e.ToString();
        }

        //medium mode
        if (hunt_m < score2)
        {
            hunt_m = score2;
            m1.text= hunt_m.ToString();
        }

        //hard mode
        if (hunt_h < score3)
        {
            hunt_h = score3;
            h1.text= hunt_h.ToString();
        }

    }
}
