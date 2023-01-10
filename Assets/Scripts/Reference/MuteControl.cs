using System.Collections;
using UnityEngine;

public class MuteControl : MonoBehaviour
{
    public GameObject soundsManagement;
    public GameObject labelSoundON;
    public GameObject labelSoundOff;
   
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MuteManagement();
        }
    }

    private void MuteManagement()
    {
        if (soundsManagement.activeSelf){
            soundsManagement.SetActive(false);
            labelSoundOff.SetActive(true);
            labelSoundON.SetActive(false);
        } else 
        {
            soundsManagement.SetActive(true);
            labelSoundOff.SetActive(false);
            labelSoundON.SetActive(true);
        }
    }
}
