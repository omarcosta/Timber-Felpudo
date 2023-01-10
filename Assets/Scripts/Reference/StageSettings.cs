using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*namespace StageSettingsControl 
{*/
    public class StageSettings : MonoBehaviour
    {   
        [Header("Stage Settings")]
        public int stagepoints = 15; // <-- 15 Default
        private int points = 0;
        
        [Header("Text Settings")]
        public Text score;
        public Text Win;
        public GameObject author;
        public GameObject panel;

        [Header("Stopwatch Instance")]
        [SerializeField] stopwatch stopwatch;

        void Start()
        {
            score.text = "Score: " + points.ToString() + " / " + stagepoints.ToString();
            
        }

        
        void Update()
        {
            if (points >= stagepoints)
            {
                if (stopwatch != null)
                {
                    stopwatch.StopWatchTime();             
                } else 
                {
                    print("Stopwatch is a instance NULL at \"Stage Settings\". Select \"Stage Controller\" at Inspector");
                }
            // Call class Stopwath func StopWatchTime()   
            }
        }

        public void SetScore()
        {
            points ++;
            print("points is " + points);
            score.text = "Score: " + points.ToString() + " / " + stagepoints.ToString();
            if (points >= stagepoints) 
            {
                // finalTime.text = timerText;
                Win.text = "YOU WIN!!!";
                author.SetActive(true);
                panel.SetActive(true);
            } 
        }
    }

//}