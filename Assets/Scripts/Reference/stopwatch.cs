using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class stopwatch : MonoBehaviour
{   
    [Header("Component Cronometer")]
    public Text timerText;
    private float currentTime;
    private int minute;
    public bool stop = false;
  
    void Update()
    {
        if (!stop)
        {
            currentTime = currentTime += Time.deltaTime;
        }
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

    public void StopWatchTime(){
        stop = true;
    }

}
