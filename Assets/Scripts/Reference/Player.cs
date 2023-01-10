using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public float jump = 500f;
    public float gravity = 2.5f;
    public GameObject touchParticles;
    public GameObject impactParticles;
    private AudioSource sound_collision;
    private AudioSource sound_impulse;
    private AudioSource sound_airplane;
    private AudioSource sound_airplane_down;

    
    private bool start = false;
    private bool finish = false;
    private Rigidbody2D playerbody;
    private Vector2 impulse;

    public GameController myGameController;
  
    private void Awake() {
       playerbody = GetComponent<Rigidbody2D>();
       impulse = new Vector2(0,jump);   
    }
    
    void Start() {
       sound_impulse = GameObject.Find("Sounds/Impulse").GetComponent<AudioSource>();
       sound_collision = GameObject.Find("Sounds/Collision").GetComponent<AudioSource>();
       sound_airplane = GameObject.Find("Sounds/Airplane").GetComponent<AudioSource>();
       sound_airplane_down = GameObject.Find("Sounds/AirplaneDown").GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (!finish)
        {
            if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") )
            {
                if(!start)
                {
                   playerbody.gravityScale = gravity;
                   start = true;
                   //myGameController.GameStart();
                }
                sound_impulse.Play();

                playerbody.velocity = new Vector2(0,0);
                playerbody.AddForce(impulse);
            
                GameObject featherAnim = Instantiate(touchParticles);
                featherAnim.transform.position = new Vector3(this.transform.position.x, this.transform.position.y +1f, this.transform.position.z +3);
            }
            transform.rotation = Quaternion.Euler(0,0,playerbody.velocity.y * 3);
        }
        AreaLimit();
   
    }

    private void AreaLimit() { // Exceeded the upper or lower area
        float heightPlayPixel = Camera.main.WorldToScreenPoint(transform.position).y;

        if(heightPlayPixel > Screen.height + 200 || heightPlayPixel < 0)
        {
            FinishGame();   
        } 
    }

    void OnCollisionEnter2D() { // Collision with Enemy
        FinishGame();
    }

    private void FinishGame()
    {
        if (!finish)
        {
            finish = true;
            GameObject impactAnim = Instantiate(impactParticles);
            sound_collision.Play();
            impactAnim.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z -3);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(200,-10));
            GetComponent<Rigidbody2D>().AddTorque(300f);
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.5f);
            myGameController.GameOver();
            sound_airplane.Stop();
            sound_airplane_down.Play();

        
        }
    }
}
