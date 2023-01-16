// using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TryAgain : MonoBehaviour
{
    public Text _score;
    public Button _buttonRestart;
    public Button _buttonExit;
    public Button _buttonClose;
    private void Awake() {
        UpdateScore();
    }

    void Start()
    {
        _buttonRestart.onClick.AddListener(PlayAgain);  
        _buttonExit.onClick.AddListener(GoToMain); 
        _buttonClose.onClick.AddListener(CloseWindow);  
    }
    

    void Update() 
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter") || Input.GetKeyDown("return")){
           PlayAgain();
        }
    }
    private void UpdateScore()
    {
        int _getScore = StageController.GetScore;
        _score.text = "Score: " + _getScore.ToString();
    }

    private void CloseWindow() { 
        // this.gameObject.SetActive(false);
        GoToMain(); 
    }
    private void PlayAgain() { SceneManager.LoadScene("Game", LoadSceneMode.Single); }
    private void GoToMain() { SceneManager.LoadScene("Main", LoadSceneMode.Single); }
}
