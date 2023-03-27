using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntModeScript : MonoBehaviour
{
    //button creation for game mode hunt screen
    [SerializeField] Button backButton1;
    [SerializeField] Button startHuntButton;

    // Start is called before the first frame update
    void Start()
    {
        backButton1.onClick.AddListener(ToMain);
        startHuntButton.onClick.AddListener(ToHunt);

    }

    private void ToMain()
    {
        SceneLoader.Instance.LoadMain();
    }
    private void ToHunt()
    {
        SceneLoader.Instance.LoadNewHuntGame();
    }
}
