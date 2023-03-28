using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{   
    //button creation for main screen
    [SerializeField] Button huntButton;
    [SerializeField] Button houseButton;
    [SerializeField] Button statsButton;
    [SerializeField] Button scoresButton;
    [SerializeField] Button exitButton;


    void Start()
    {
        huntButton.onClick.AddListener(ToModeHunt);
        houseButton.onClick.AddListener(ToModeHouse);
        statsButton.onClick.AddListener(ToStatistics);
        scoresButton.onClick.AddListener(ToScores);
        exitButton.onClick.AddListener(Leave);
    }


    private void ToModeHunt()//calls hunt gamemode page
    {
        SceneLoader.Instance.LoadModeHunt();
    }
    private void ToModeHouse()//calls house gamemode page
    {
        SceneLoader.Instance.LoadModeHouse();
    }
    private void ToStatistics()//calls statistics page
    {
        SceneLoader.Instance.LoadStats();
    }
    private void ToScores()//calls statistics page
    {
        SceneLoader.Instance.LoadScores();
    }
    private void Leave()//exit
    {
        Application.Quit();
    }
    

}
