using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntScript : MonoBehaviour
{
    //button creation for hunt screen
    [SerializeField] Button exitButton1, exitButton;

    // Start is called before the first frame update
    void Start()
    {
        exitButton1.onClick.AddListener(ToMain);
        exitButton.onClick.AddListener(ToMain);
    }


    private void ToMain()
    {
        SceneLoader.Instance.LoadMain();
    }
}
