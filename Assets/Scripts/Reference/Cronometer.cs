using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add

public class Cronometer : MonoBehaviour
{
    [Header("Component Cronometer")]
    public TextMeshProUGUI timerText;
    private float currentTime;
    private int minute;
   
    
    void Update()
    {
       
        currentTime = currentTime += Time.deltaTime;
        if(currentTime > 59)
        {
            currentTime = 0;
            minute++;
        }
        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = minute.ToString("00") + ":" + currentTime.ToString("00"); 
    }
}
