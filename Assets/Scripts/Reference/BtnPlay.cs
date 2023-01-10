using UnityEngine;
using TMPro;

public class BtnPlay : MonoBehaviour
{
    public AudioSource audioSource;
    private TMP_Text m_TextComponent;
    void Start() { m_TextComponent = GetComponent<TMP_Text>(); }

    public void OnMouseEnter()
    {        
        m_TextComponent.fontSize = 30;
        m_TextComponent.color =  new Color32(114, 222, 162, 255);
        audioSource.Play();
    }

    public void OnMouseExit()
    {
        m_TextComponent.color =  new Color32(247, 247, 231, 255);
        m_TextComponent.fontSize = 25;
    }
}