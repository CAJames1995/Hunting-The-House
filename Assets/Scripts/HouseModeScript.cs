using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseModeScript : MonoBehaviour
{
    //button creation for game mode hunt screen
    [SerializeField] Button backButton2;
    [SerializeField] Button startHouseButton;

    // Start is called before the first frame update
    void Start()
    {
        backButton2.onClick.AddListener(ToMain1);
        startHouseButton.onClick.AddListener(ToHouse);

    }

    private void ToMain1()
    {
        SceneLoader.Instance.LoadMain();
    }
    private void ToHouse()
    {
        SceneLoader.Instance.LoadNewHouseGame();
    }
}
