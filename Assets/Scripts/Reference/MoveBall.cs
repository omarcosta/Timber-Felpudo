using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using StageSettingsControl;


public class MoveBall : MonoBehaviour
{
    [Header("Ball Settings")]
    private Rigidbody rb;
    public GameObject particule;
    public float velocityMin = 250;
    public float velocityDown = 100; 
    public float velocityMax = 400;
    public float velocityUp = 0.3f;
    public float velocity = 300;
    //private int points = 0;

    /*[Header("Text Settings")]
    public Text score;
    public Text Win;
    public GameObject author;
    public GameObject panel;*/

    /*[Header("Component Cronometer")]
    public Text timerText;
    private float currentTime;
    private int minute;
    private Text finalTime;*/

    [Header("Audio Crystals")]
    public AudioSource audioSource;
    public AudioClip clip;
    [Range(0.0f,1.0f)]
    public float volume = 0.4f;

    //[Header("Stage Settings")]
    //public int stagepoints = 15; // <-- 15 Default

    
    [SerializeField] StageSettings stageSettings;
    


    void Start()
    {  
        rb = GetComponent<Rigidbody>();
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        //score.text = "Score: " + points.ToString() + " / " + stagepoints.ToString();
        
    }

    void Update()
    {   
        /*if (points < stagepoints)
        {
            currentTime = currentTime += Time.deltaTime;

        }
        if(currentTime > 59)
        {
            currentTime = 0;
            minute++;
        }
        SetTimerText();*/
        
    }

    // FixedUpdate is called bettler performace em physical changes 
    void FixedUpdate()
    {
        // Vector3 position = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        // rb.AddForce(position * velocity * Time.deltaTime);
        MovePlayerRelativeToCamera();
          
    }

    void LateUpdate() 
    {
       SpeedUpBall();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("point"))
        {
            Instantiate(particule, other.gameObject.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(clip, volume);
            Destroy(other.gameObject);
            if (stageSettings != null)
            {
                stageSettings.SetScore();             
            } else 
            {
                print("StageSettings is a instance NULL at \"Ball\". Select \"Stage Controller\" at Inspector");
            }
        }
        if(other.gameObject.CompareTag("mountain"))
        {
            SlowDownBall();
        }
    
    }

    /*void SetScore()
    {
        points ++;
        score.text = "Score: " + points.ToString() + " / " + stagepoints.ToString();
        if (points >= stagepoints) 
        {
            // finalTime.text = timerText;
            Win.text = "YOU WIN!!!";
            author.SetActive(true);
            panel.SetActive(true);
        } 
    }*/

    /*private void SetTimerText()
    {
        timerText.text = minute.ToString("00") + ":" + currentTime.ToString("00"); 
    }*/
    
    private void MovePlayerRelativeToCamera() 
    {
        // Get Player Input (ORIGINAL INPUT SYSTEM)
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        // Get Camera-Normalized Directional Vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        // Create Direction-Relative Input Vectors
        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right;

        // Create Camera-Relative Movement
        Vector3 cameraRelativeMovement =  forwardRelativeVerticalInput + rightRelativeVerticalInput;;
        rb.AddForce(cameraRelativeMovement * velocity * Time.deltaTime);        
    }

    private void SpeedUpBall()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            if (velocity < velocityMax)
            {
                velocity = velocity + velocityUp;
            } else 
            {
                velocity = velocityMax;
            }

            if (velocity < velocityMin)
            {
                velocity = velocityMin;
            }
            print(velocity);
        }

    }

    private void SlowDownBall()
    {
        if (velocity > velocityMin)
        {
            velocity = velocity - velocityDown;

        } else
        {
            velocity = velocityMin;
        }


        print("bati");
    }

}
