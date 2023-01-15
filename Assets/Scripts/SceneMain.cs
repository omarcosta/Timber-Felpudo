using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMain : MonoBehaviour
{
    public Button _buttonPlay;
    public Button _buttonCredits;
    public GameObject credits;
    public Button _buttonClose;
    void Start()
    {
        _buttonPlay.onClick.AddListener(GoToGame);  
        _buttonCredits.onClick.AddListener(GoToCredits);
        _buttonClose.onClick.AddListener(CloseWindow);   
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter") || Input.GetKeyDown("return")){
           GoToGame();
        }
        
    }

    private void CloseWindow() { 
        credits.gameObject.SetActive(false); 
    }

    private void GoToGame() { SceneManager.LoadScene("Game", LoadSceneMode.Single); }

    private void GoToCredits() { credits.gameObject.SetActive(true); }
}
