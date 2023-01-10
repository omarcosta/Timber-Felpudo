using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        PressEnter();
    }

    private void PressEnter()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("enter") || Input.GetKeyDown("return")){
            SceneManager.LoadScene("SceneSnow", LoadSceneMode.Single);
        }
    }
}
