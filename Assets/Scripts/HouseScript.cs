using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseScript : MonoBehaviour
{
    //button creation for hunt screen
    [SerializeField] Button exitButton2;

    // Start is called before the first frame update
    void Start()
    {
        exitButton2.onClick.AddListener(ToMain);
    }


    private void ToMain()
    {
        SceneLoader.Instance.LoadMain();
    }
}
