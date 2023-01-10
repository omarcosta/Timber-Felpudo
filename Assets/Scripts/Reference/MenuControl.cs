
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    public GameObject logo;
    public GameObject bg;
    
    private void Awake() {
        CanvasGUI();
    }

    private void CanvasGUI() {
        // Apply Logo - Position and scale
        logo.transform.position = new Vector2(Screen.width/4,Screen.height/1.35f);
        RectTransform logoRT = bg.GetComponent<RectTransform>();
        logoRT.sizeDelta = new Vector2(Screen.width/1.5f,Screen.height/1.5f);
        // Full screen - Apply to BG
        bg.transform.position = new Vector2(Screen.width/2,Screen.height/2f);
        RectTransform bgRT = bg.GetComponent<RectTransform>();
        bgRT.sizeDelta = new Vector2(Screen.width,Screen.height);
    }
}
