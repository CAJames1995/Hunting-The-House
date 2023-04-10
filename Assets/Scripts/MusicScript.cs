using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Base cript is from the Unity Forum posted by Denvery and edited by NuffuruDevelopment. 
 * Free use of all scripts posted under this topic were given by the forum users in the comments.
 * 
 * Link: https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html
 * */

public class MusicScript : MonoBehaviour
{
    private AudioSource _audioSource;
    private GameObject[] other;
    private bool NotFirst = false;
    public enum Scene
    {
        Main,
        GameModeHunt,
        Hunt,
        GameModeHouse,
        House,
        Scores,

    }


    private void Awake()
    {
        other = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                NotFirst = true;
            }
        }

        if (NotFirst == true)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "Hunt" || SceneManager.GetActiveScene().name == "House")
        {

               StopMusic();
        }
        else
        {
            PlayMusic();
        }

    }
}
