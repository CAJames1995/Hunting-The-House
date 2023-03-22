/*
 * Base code is by Dani Krossing
 *Found on youtuve titled "CHANGE SCENE WITH BUTTON IN UNITY |Scene Manager in Unity| Learn Unity"
 *https://www.youtube.com/watch?v=jrPTpD2eAMw
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    private void Awake()
    {
        Instance= this;
    }

    // Creates an index to call the scenes.
    // Ensure this list is the SAME ORDER in BUILD SETTINGS
    public  enum Scene  
    {
        Main,
        GameModeHunt,
        Hunt,
        GameModeHouse,
        House,
        Stats,
        Settings,
        BlankAR

    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    public void LoadMain()
    {
        SceneManager.LoadScene(Scene.Main.ToString());
    }
    public void LoadNewHuntGame()
    {
        SceneManager.LoadScene(Scene.Hunt.ToString());
    }
    public void LoadNewHouseGame()
    {
        SceneManager.LoadScene(Scene.House.ToString());
    }
    public void LoadModeHunt()
    {
        SceneManager.LoadScene(Scene.GameModeHunt.ToString());
    }
    public void LoadModeHouse()
    {
        SceneManager.LoadScene(Scene.GameModeHouse.ToString());
    }
    public void LoadStats()
    {
        SceneManager.LoadScene(Scene.Stats.ToString());
    }
     public void LoadSettings()
    {
        SceneManager.LoadScene(Scene.Settings.ToString());
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void LoadLastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

}