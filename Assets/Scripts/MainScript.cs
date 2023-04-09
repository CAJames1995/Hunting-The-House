using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{   
    //button creation for main screen
    [SerializeField] Button huntButton;
    [SerializeField] Button houseButton;
    [SerializeField] Button scoresButton;


    void Start()
    {
        huntButton.onClick.AddListener(ToModeHunt);
        houseButton.onClick.AddListener(ToModeHouse);
        scoresButton.onClick.AddListener(ToScores);
    }


    private void ToModeHunt()//calls hunt gamemode page
    {
        SceneLoader.Instance.LoadModeHunt();
    }
    private void ToModeHouse()//calls house gamemode page
    {
        SceneLoader.Instance.LoadModeHouse();
    }
 
    private void ToScores()//calls statistics page
    {
        SceneLoader.Instance.LoadScores();
    }
 

}
