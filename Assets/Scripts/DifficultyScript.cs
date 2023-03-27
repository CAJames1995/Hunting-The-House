using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DifficultyScript:MonoBehaviour
{
    [SerializeField] private Slider difficulty;
    public TMP_Text levellabel;
    public static int levelint=5;
    void Start()
    {

        difficulty.onValueChanged.AddListener((v) =>{
            levelint = (int)v;
            if (v == 5)
            {
                levellabel.text = "Easy";
            }
            else if(v == 4)
            {
                levellabel.text = "Medium";
            }
            else if (v == 3)
            {
                levellabel.text = "Hard";
            }

        });
        levelint = 5;
        
    }



   
}
