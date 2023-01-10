using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene Management")]
    public string sceneName;
    public bool replace;

    public void StartSM() {
        SceneManagement(sceneName, replace);
    }

    public void SceneManagement(string sceneName, bool replace)
    {
        if (sceneName != null)
        {
            if (replace) 
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

            } else 
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }

        } else {
            print("Parameters null");
        }
        
    }

}




/*using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void SceneSnowBall()
    {
        // LoadSceneMode.Additive for adds the Scene to the current loaded Scenes.
        // LoadSceneMode.Single	for loses all current loaded Scenes and loads a Scene
        SceneManager.LoadScene("SceneSnow", LoadSceneMode.Single);
    }
}*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start() 
    {
        LoadScene();
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
*/ 