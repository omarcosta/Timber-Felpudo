//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Header("Add buttons...")]
    public Button _buttonPlay;
    void Start()
    {
        _buttonPlay.onClick.AddListener(LoadScene);   
        
    }

    private void FixedUpdate() {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("return") ) { 
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
